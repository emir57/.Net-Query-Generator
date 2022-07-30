﻿using System.Linq.Expressions;

namespace WriteParameter
{
    public interface IQueryGenerate<TEntity>
        where TEntity : class
    {
        string GenerateGetAllQuery();
        string GenerateGetByIdQuery();
        string GenerateGetByIdQuery(int id);
        string GenerateGetByIdQuery(string id);

    }
}
