using Microsoft.EntityFrameworkCore;

namespace Fitfuel.Shared.Persistence.Specifications;

public class SpecificationEvaluator
{
    public static IQueryable<T> GetQuery<T>(
        IQueryable<T> inputQueryable,
        BaseSpecification<T> specification)
        where T : class
    {
        IQueryable<T> queryable = inputQueryable;

        if (specification.Criteria is not null)
        {
            queryable = queryable.Where(specification.Criteria);
        }

        specification.IncludeExpressions.Aggregate(
            queryable,
            (current, includeExpression) =>
                current.Include(includeExpression));

        if (specification.OrderByExpression is not null)
        {
            queryable = queryable.OrderBy(
                specification.OrderByExpression);
        }
        else if (specification.OrderByDescExpression is not null)
        {
            queryable = queryable.OrderBy(
                specification.OrderByDescExpression);
        }

        return queryable;

    }
}