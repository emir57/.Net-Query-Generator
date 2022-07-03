using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WriteParameter.Abstract;

namespace WriteParameter.Concrete
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

        public string Generate()
        {
            return _query;
        }

        public IQueryGenerate<TEntity> GenerateInsertQuery()
        {
            if (_tableName is null)
                _query = insertIntoWriteParameters();
            else
                _query = String.Format($"insert into {_tableName} {insertIntoWriteParameters()}");
            return this;
        }

        public IQueryGenerate<TEntity> GenerateUpdateQuery()
        {
            if (_tableName is null)
                _query = updateWriteParameters();
            else
                _query = String.Format($"update {_tableName} {updateWriteParameters()}");
            return this;
        }

        public IQueryGenerate<TEntity> SetTableName(string tableName)
        {
            _tableName = tableName;
            return this;
        }

        public IQueryGenerate<TEntity> SelectColumn<TProperty>(Expression<Func<TEntity, TProperty>> predicate)
        {
            PropertyInfo propertyInfo = (predicate.Body as MemberExpression).Member as PropertyInfo;
            _properties.Add(propertyInfo);
            return this;
        }

        private string getIdColumn(PropertyInfo[] properties)
        {
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
            var properties = typeof(TEntity).GetProperties();
            string idPropertyName = getIdColumn(properties);

            string updateQuery = String.Join(",", properties.Select(p => p.Name == idPropertyName ? "" : $"{p.Name}=@{p.Name}"));

            updateQuery = updateQuery.StartsWith(",") ? updateQuery.Substring(1) : updateQuery;
            updateQuery += String.Concat(" ", $"where {idPropertyName}=@{idPropertyName}");
            return $"set {updateQuery}";
        }
        private string insertIntoWriteParameters()
        {
            var properties = typeof(TEntity).GetProperties();
            string idPropertyName = getIdColumn(properties);

            string columns = String.Join(",", properties.Select(p => p.Name == idPropertyName ? "" : p.Name));
            string valueColumns = String.Join(",", properties.Select(p => p.Name == idPropertyName ? "" : $"@{p.Name}"));

            columns = columns.StartsWith(",") ? columns.Substring(1) : columns;
            valueColumns = valueColumns.StartsWith(",") ? valueColumns.Substring(1) : valueColumns;
            return $"({columns}) values ({valueColumns})";
        }
    }
}
