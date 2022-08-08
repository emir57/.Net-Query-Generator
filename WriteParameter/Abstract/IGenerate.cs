using System.Linq.Expressions;

namespace WriteParameter.Abstract
{
    public interface IGenerate<TEntity> :
        ICommandGenerate, IQueryGenerate<TEntity>
        where TEntity : class
    {
        IGenerate<TEntity> TableName(string tableName);
        IGenerate<TEntity> TableName(string tableName, string schema);
        IGenerate<TEntity> SchemaName(string schema);
        IGenerate<TEntity> SelectColumn<TProperty>(Expression<Func<TEntity, TProperty>> expression);
        IGenerate<TEntity> SelectIdColumn<TProperty>(Expression<Func<TEntity, TProperty>> expression);
        IGenerate<TEntity> SelectIdColumn<TProperty>(string idColumn);
        IGenerate<TEntity> SetLimit(int limit);
        IGenerate<TEntity> SetOffset(int offset);
    }
}
