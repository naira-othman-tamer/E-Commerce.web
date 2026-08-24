using Domain.Contracts;
using Domain.Models;
using System.Linq.Expressions;

namespace ServiceImplementation.Specifications;

public abstract class BaseSpecification<TEntity, TKey> : ISpecifications<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    protected BaseSpecification(Expression<Func<TEntity,bool>> CriteriaExpression)
    {
        Criteria = CriteriaExpression;
    }
    public Expression<Func<TEntity, bool>> Criteria { get; private set; }

    public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = [];
    protected void AddIncludes(Expression<Func<TEntity, object>> IncludeExpression) => 
        IncludeExpressions.Add(IncludeExpression);
}
