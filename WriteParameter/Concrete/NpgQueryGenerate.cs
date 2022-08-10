using System.Linq.Expressions;
using System.Reflection;
using WriteParameter.Abstract;

namespace WriteParameter
{
    public class NpgQueryGenerate<TEntity> : QueryGenerate<TEntity>
        where TEntity : class
    {
        public NpgQueryGenerate()
        {
        }

        public NpgQueryGenerate(string tableName) : base(tableName)
        {
        }

        public NpgQueryGenerate(IEnumerable<PropertyInfo> properties) : base(properties)
        {
        }

        public NpgQueryGenerate(PropertyInfo[] properties) : base(properties)
        {
        }

        protected override string getParametersWithId(string? previousName = "", string? lastName = "")
        {
            return base.getParametersWithId("\"", "\"");
        }
        protected override string getParametersWithoutId(string? previousName = "", string? lastName = "")
        {
            return base.getParametersWithoutId("\"", "\"");
        }
        protected override string GetAllOrderBy<TProperty>(string orderBy, Expression<Func<TEntity, TProperty>> expression, string? previousName = "", string? lastName = "")
        {
            return base.GetAllOrderBy(orderBy, expression, "\"", "\"");
        }
        protected override string GetAllOrderByDescending<TProperty>(string orderBy, Expression<Func<TEntity, TProperty>> expression, string? previousName = "", string? lastName = "")
        {
            return base.GetAllOrderByDescending(orderBy, expression, "\"", "\"");
        }
        protected override string getIdColumn(string? previousName = "", string? lastName = "", bool isValue = false)
        {
            return base.getIdColumn("\"", "\"");
        }
        protected override string updateWriteParameters(string? previousName = "", string? lastName = "")
        {
            return base.updateWriteParameters("\"", "\"");
        }
        public override IGenerate<TEntity> TableName(string tableName)
        {
            return base.TableName($"\"{tableName}\"");
        }
        protected override void getPagination(string pagination = "")
        {
            base.getPagination($"limit {_limit} offset {_offset}");
        }
        protected override string generateDeleteQuery(string previousName = "", string lastName = "")
        {
            return base.generateDeleteQuery("\"", "\"");
        }
    }
}
