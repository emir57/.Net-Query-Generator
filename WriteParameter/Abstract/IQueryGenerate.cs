using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WriteParameter
{
    public interface IQueryGenerate<TEntity>
        where TEntity : class
    {
        string GenerateInsertQuery();
        string GenerateUpdateQuery();
        string GenerateGetAllQuery();
        IQueryGenerate<TEntity> SetTableName(string tableName);
        IQueryGenerate<TEntity> SelectColumn<TProperty>(Expression<Func<TEntity, TProperty>> predicate);
    }
}
