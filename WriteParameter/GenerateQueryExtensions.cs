using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenerateQuery
{
    public static class GenerateQueryExtensions
    {

        public static string GenerateInsertQuery<T>(this T entity)
        {
            return insertIntoWriteParameters(entity);
        }
        public static string GenerateInsertQuery<T>(this T entity, string tableName)
        {
            return String.Format($"insert into {tableName} {insertIntoWriteParameters(entity)}");
        }
        public static string GenerateUpdateQuery<T>(this T entity)
        {
            return updateWriteParameters(entity);
        }
        public static string GenerateUpdateQuery<T>(this T entity, string tableName)
        {
            return String.Format($"update {tableName} {updateWriteParameters(entity)}");
        }

        private static string getIdColumn(PropertyInfo[] properties)
        {
            PropertyInfo tryGetId = properties.FirstOrDefault(p => p.Name.ToUpper() == "ID");
            if (tryGetId is null)
            {
                PropertyInfo tryGetContainsId = properties.FirstOrDefault(p => p.Name.ToUpper().Contains("ID"));
                return tryGetContainsId.Name;
            }
            return tryGetId.Name;
        }

        private static string updateWriteParameters<T>(T entity)
        {
            var properties = entity.GetType().GetProperties();
            string idPropertyName = getIdColumn(properties);

            string updateQuery = String.Join(",", properties.Select(p => p.Name == idPropertyName ? "" : $"{p.Name}=@{p.Name}"));
            
            updateQuery = updateQuery.StartsWith(",") ? updateQuery.Substring(1) : updateQuery;
            updateQuery += String.Concat(" ", $"where {idPropertyName}=@{idPropertyName}");
            return $"set {updateQuery}";
        }
        private static string insertIntoWriteParameters<T>(T entity)
        {
            var properties = entity.GetType().GetProperties();
            string idPropertyName = getIdColumn(properties);

            string columns = String.Join(",", properties.Select(p => p.Name == idPropertyName ? "" : p.Name));
            string valueColumns = String.Join(",", properties.Select(p => p.Name == idPropertyName ? "" : $"@{p.Name}"));
            
            columns = columns.StartsWith(",") ? columns.Substring(1) : columns;
            valueColumns = valueColumns.StartsWith(",") ? valueColumns.Substring(1) : valueColumns;
            return $"({columns}) values ({valueColumns})";
        }
    }
}
