using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WriteParameter
{
    public static class Extensions
    {

        public static string InsertIntoWriteParameters<T>(this T entity)
        {
            var properties = entity.GetType().GetProperties();
            string columns = String.Join(",", properties.Select(p => p.Name.ToUpper().Contains("ID") ? "" : p.Name));
            string valueColumns = String.Join(",", properties.Select(p => p.Name.ToUpper().Contains("ID") ? "" : $"@{p.Name}"));
            columns = columns.StartsWith(",") ? columns.Substring(1) : columns;
            valueColumns = valueColumns.StartsWith(",") ? valueColumns.Substring(1) : valueColumns;
            return $"({columns}) values ({valueColumns})";
        }
        public static string UpdateWriteParameters<T>(this T entity)
        {
            var properties = entity.GetType().GetProperties();
            string idPropertyName = properties.FirstOrDefault(p => p.Name.ToUpper().Contains("ID")).Name;
            string columnsWithValueColumns = String.Join(",", properties.Select(p => p.Name.ToUpper().Contains("ID") ? "" : $"{p.Name}=@{p.Name}"));
            columnsWithValueColumns = columnsWithValueColumns.StartsWith(",") ? columnsWithValueColumns.Substring(1) : columnsWithValueColumns;
            columnsWithValueColumns += String.Concat(" ", $"where {idPropertyName}=@{idPropertyName}");
            return $"set {columnsWithValueColumns}";
        }
    }
}
