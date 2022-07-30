﻿using System.Reflection;

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

        protected override string getParametersWithId(string? previousName = "\"", string? lastName = "\"")
        {
            return base.getParametersWithId("\"", "\"");
        }
        protected override string getParametersWithoutId(string? previousName = "", string? lastName = "\"")
        {
            return base.getParametersWithoutId("\"", "\"");
        }
        protected override string GetAllOrderBy<TProperty>(string orderBy, System.Linq.Expressions.Expression<Func<TEntity, TProperty>> expression, string? previousName = "", string? lastName = "")
        {
            return base.GetAllOrderBy(orderBy, expression, "\"", "\"");
        }
        protected override string GetAllOrderByDescending<TProperty>(string orderBy, System.Linq.Expressions.Expression<Func<TEntity, TProperty>> expression, string? previousName = "", string? lastName = "")
        {
            return base.GetAllOrderByDescending(orderBy, expression, "\"", "\"");
        }
    }
}
