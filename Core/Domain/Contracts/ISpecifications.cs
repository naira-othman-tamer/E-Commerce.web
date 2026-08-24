using Domain.Models;
using System.Linq.Expressions;

namespace Domain.Contracts;

public interface ISpecifications<TEntity,TKey> where TEntity : BaseEntity<TKey>
{
    /// <summary>
    /// Gets the filtering expression used to define the WHERE condition of the query.
    /// </summary>
    public Expression<Func<TEntity,bool>>? Criteria { get; }
    /// <summary>
    /// Gets the collection of expressions representing the navigation properties
    /// that should be included in the query.
    /// </summary>
    public List<Expression<Func<TEntity,object>>> IncludeExpressions { get; }
}
