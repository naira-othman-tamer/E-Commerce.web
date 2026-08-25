using Domain.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace Persistence.Helper;

static class SpecificationEvaluator
{
    public static IQueryable<TEntity> CreateQuery<TEntity, TKey>(
         IQueryable<TEntity> entryPoint,
         ISpecifications<TEntity,TKey> specifications)
         where TEntity : BaseEntity<TKey> {
        var Query = entryPoint;
        if (specifications.Criteria != null) 
            Query = Query.Where(specifications.Criteria);
        if(specifications.orderBy is not null)
        {
            Query = Query.OrderBy(specifications.orderBy);
        }
        if(specifications.orderByDescending is not null)
        {
            Query = Query.OrderByDescending(specifications.orderByDescending);
        }
        if (specifications.IncludeExpressions != null && specifications.IncludeExpressions.Count > 0) {
            //foreach (var expression in specifications.IncludeExpressions)
            //    Query = Query.Include(expression);
            Query = specifications
                    .IncludeExpressions
                    .Aggregate(Query, (currentQuery,
                    includeExpression) => currentQuery.Include(includeExpression));
        }
        return Query;
    }
}
