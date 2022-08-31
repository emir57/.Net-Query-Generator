﻿using WriteParameter.MsSqlWriter;
using WriteParameter.NpgWriter;

namespace WriteParameter.Extensions
{
    public static class WriteParameterCommandExtensions
    {
        public static string MsSqlAddQuery<T>(this T @object, string schema = "dbo", string tableName = null)
            where T : class
        {
            MsSqlQueryGenerate<T> generator = new MsSqlQueryGenerate<T>();

            if (tableName != null)
                generator.TableName(tableName);
            generator.SchemaName(schema);

            string query = generator.GenerateInsertQuery();
            return query;
        }
        public static string NpgAddQuery<T>(this T @object, string schema = "dbo", string tableName = null)
            where T : class
        {
            NpgQueryGenerate<T> generator = new NpgQueryGenerate<T>();

            if (tableName != null)
                generator.TableName(tableName);
            generator.SchemaName(schema);

            string query = generator.GenerateInsertQuery();
            return query;
        }
    }
}
