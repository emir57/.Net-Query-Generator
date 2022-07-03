using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WriteParameter.Abstract;

namespace WriteParameter.Concrete
{
    public class QueryGenerate<TEntity> : IQueryGenerate<TEntity>
        where TEntity : class
    {
        private string _query;
        private string _tableName;
        public QueryGenerate(string tableName)
        {
            _tableName = tableName;
        }
        public string Generate()
        {
            return _query;
        }

        public IQueryGenerate<TEntity> GenerateInsertQuery()
        {
            _query = String.Format($"insert into {_tableName} {insertIntoWriteParameters()}");
            return this;
        }

        public IQueryGenerate<TEntity> GenerateUpdateQuery()
        {
            _query = String.Format($"update {_tableName} {updateWriteParameters()}");
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
            var properties = typeof(TEntity).GetType().GetProperties();
            string idPropertyName = getIdColumn(properties);

            string updateQuery = String.Join(",", properties.Select(p => p.Name == idPropertyName ? "" : $"{p.Name}=@{p.Name}"));

            updateQuery = updateQuery.StartsWith(",") ? updateQuery.Substring(1) : updateQuery;
            updateQuery += String.Concat(" ", $"where {idPropertyName}=@{idPropertyName}");
            return $"set {updateQuery}";
        }
        private string insertIntoWriteParameters()
        {
            var properties = typeof(TEntity).GetType().GetProperties();
            string idPropertyName = getIdColumn(properties);

            string columns = String.Join(",", properties.Select(p => p.Name == idPropertyName ? "" : p.Name));
            string valueColumns = String.Join(",", properties.Select(p => p.Name == idPropertyName ? "" : $"@{p.Name}"));

            columns = columns.StartsWith(",") ? columns.Substring(1) : columns;
            valueColumns = valueColumns.StartsWith(",") ? valueColumns.Substring(1) : valueColumns;
            return $"({columns}) values ({valueColumns})";
        }
    }
}
