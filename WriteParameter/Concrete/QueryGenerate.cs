using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WriteParameter.Exceptions;

namespace WriteParameter
{
    public class QueryGenerate<TEntity> : IQueryGenerate<TEntity>
        where TEntity : class
    {
        private List<PropertyInfo> _properties;
        private string _query;
        private string _tableName;

        public QueryGenerate()
        {
            _properties = new List<PropertyInfo>();
        }

        public string GenerateInsertQuery()
        {
            checkTable();
            return String.Format($"insert into {_tableName} {insertIntoWriteParameters()}");
        }

        public string GenerateUpdateQuery()
        {
            checkTable();
            return String.Format($"update {_tableName} {updateWriteParameters()}");
        }
        public string GenerateDeleteQuery()
        {
            checkTable();
            string idPropertyName = getIdColumn();
            return String.Format($"delete from {_tableName} where {idPropertyName}=@{idPropertyName}");
        }

        public IQueryGenerate<TEntity> SelectTable(string tableName)
        {
            _tableName = tableName;
            return this;
        }

        public string GenerateGetAllQuery()
        {
            checkTable();
            string parameters = getParametersWithId();
            string query = String.Format($"select {parameters} from {_tableName}");
            return query;
        }

        public string GenerateGetByIdQuery()
        {
            checkTable();
            string parameters = getParametersWithId();
            string idColumn = getIdColumn();
            string query = String.Format($"select {parameters} from {_tableName} where {idColumn}=@{idColumn}");
            return query;
        }

        public IQueryGenerate<TEntity> SelectColumn<TProperty>(Expression<Func<TEntity, TProperty>> predicate)
        {
            PropertyInfo propertyInfo = (predicate.Body as MemberExpression).Member as PropertyInfo;
            _properties.Add(propertyInfo);
            return this;
        }

        private void checkTable()
        {
            if (_tableName is null)
                throw new NoSelectedTableException();
        }

        private string getIdColumn()
        {
            var properties = typeof(TEntity).GetProperties().ToList();
            PropertyInfo tryGetId = properties.FirstOrDefault(p => p.Name.ToUpper() == "ID");
            if (tryGetId is null)
            {
                PropertyInfo tryGetContainsId = properties.FirstOrDefault(p => p.Name.ToUpper().Contains("ID"));
                return tryGetContainsId.Name;
            }
            return tryGetId.Name;
        }

        private string updateWriteParameters()
        {
            var properties = _properties.Count == 0 ? typeof(TEntity).GetProperties().ToList() : _properties;
            string idPropertyName = getIdColumn();

            string updateQuery = String.Join(",", properties.Select(p => p.Name == idPropertyName ? "" : $"{p.Name}=@{p.Name}"));

            updateQuery = updateQuery.StartsWith(",") ? updateQuery.Substring(1) : updateQuery;
            updateQuery += String.Concat(" ", $"where {idPropertyName}=@{idPropertyName}");
            return $"set {updateQuery}";
        }
        private string insertIntoWriteParameters()
        {
            var properties = _properties.Count == 0 ? typeof(TEntity).GetProperties().ToList() : _properties;
            string idPropertyName = getIdColumn();

            string columns = getParametersWithoutId();
            string valueColumns = getParametersWithoutId("@");
            return $"({columns}) values ({valueColumns})";
        }

        private string getParametersWithoutId(string? previousName = "")
        {
            var properties = _properties.Count == 0 ? typeof(TEntity).GetProperties().ToList() : _properties;
            string idPropertyName = getIdColumn();
            string parameters = String.Join(",", properties.Select(p => p.Name == idPropertyName ? "" : $"{previousName}{p.Name}"));
            parameters = parameters.StartsWith(",") ? parameters.Substring(1) : parameters;
            return parameters;
        }
        private string getParametersWithId(string? previousName = "")
        {
            var properties = _properties.Count == 0 ? typeof(TEntity).GetProperties().ToList() : _properties;
            string parameters = String.Join(",", properties.Select(p => $"{previousName}{p.Name}"));
            parameters = parameters.StartsWith(",") ? parameters.Substring(1) : parameters;
            return parameters;
        }

    }
}
