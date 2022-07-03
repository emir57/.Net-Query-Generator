using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteParameter.Abstract
{
    public interface IQueryGenerate<TEntity>
        where TEntity : class
    {
        IQueryGenerate<TEntity> GenerateInsertQuery();
        IQueryGenerate<TEntity> GenerateUpdateQuery();
        IQueryGenerate<TEntity> SetTableName(string tableName);
        string Generate();
    }
}
