using WriteParameter.MsSqlWriter;

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
    }
}
