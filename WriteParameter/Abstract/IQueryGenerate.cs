using System.Linq.Expressions;

namespace WriteParameter
{
    public interface IQueryGenerate<TEntity>
        where TEntity : class
    {
        string GenerateInsertQuery();
        string GenerateUpdateQuery();
        string GenerateDeleteQuery();
        string GenerateGetAllQuery();
        string GenerateGetByIdQuery();
        string GenerateGetByIdQuery(int id);
        string GenerateGetByIdQuery(string id);
        IQueryGenerate<TEntity> SelectTable(string tableName);
        IQueryGenerate<TEntity> SelectColumn<TProperty>(Expression<Func<TEntity, TProperty>> expression);
        IQueryGenerate<TEntity> SelectIdColumn<TProperty>(Expression<Func<TEntity, TProperty>> expression);
    }
}
