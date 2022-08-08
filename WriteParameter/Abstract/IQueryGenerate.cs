using System.Linq.Expressions;

namespace WriteParameter
{
    public interface IQueryGenerate<TEntity>
        where TEntity : class
    {
        string GenerateGetAllQuery(bool pagination = false);
        string GenerateGetByIdQuery();
        string GenerateGetByIdQuery(int id);
        string GenerateGetByIdQuery(string id);

        string GenerateGetAllOrderBy<TProperty>(Expression<Func<TEntity, TProperty>> expression);
        string GenerateGetAllOrderByDescending<TProperty>(Expression<Func<TEntity, TProperty>> expression);

    }
}
