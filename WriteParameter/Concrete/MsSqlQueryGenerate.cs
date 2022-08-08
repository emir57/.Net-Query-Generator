using System.Reflection;

namespace WriteParameter
{
    public class MsSqlQueryGenerate<TEntity> : QueryGenerate<TEntity>
        where TEntity : class
    {
        public MsSqlQueryGenerate()
        {
        }

        public MsSqlQueryGenerate(string tableName) : base(tableName)
        {
        }

        public MsSqlQueryGenerate(IEnumerable<PropertyInfo> properties) : base(properties)
        {
        }
    }
}
