using Domain.Models;
using System.Linq.Expressions;

namespace Domain.Contracts;

public interface ISpecifications<TEntity,TKey> where TEntity : BaseEntity<TKey>
{
    //property signature for each dynamic part in Query
    public Expression<Func<TEntity,bool>> Criteria { get; }
    public List<Expression<Func<TEntity,object>>> IncludeExpressions { get; }
}
