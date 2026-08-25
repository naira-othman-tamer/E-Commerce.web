using Domain.Contracts;
using Domain.Models;
using System.Linq.Expressions;
namespace ServiceImplementation.Specifications;

public abstract class BaseSpecification<TEntity, TKey> 
    : ISpecifications<TEntity, TKey> where TEntity : BaseEntity<TKey>
{
    #region Include
    /// <summary>
    /// Initializes a new specification with an optional filtering criterion.
    /// </summary>
    /// <param name="CriteriaExpression">
    /// An optional expression that defines the filtering criteria for the entity.
    /// </param>
    protected BaseSpecification(Expression<Func<TEntity, bool>>? CriteriaExpression)
    {
        Criteria = CriteriaExpression;
    }
    /// <summary>
    /// Gets the filtering expression used to define the WHERE condition of the query.
    /// </summary>
    public Expression<Func<TEntity, bool>>? Criteria { get; private set; }
    /// <summary>
    /// Gets the collection of expressions representing the navigation properties
    /// that should be included in the query.
    /// </summary>
    public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = [];

    /// <summary>
    /// Adds a navigation property expression to the collection of includes.
    /// </summary>
    /// <param name="IncludeExpression">
    /// An expression that identifies the navigation property to include in the query.
    /// </param>
    protected void AddIncludes(Expression<Func<TEntity, object>> IncludeExpression) =>
        IncludeExpressions.Add(IncludeExpression);
    #endregion

    #region Sorting
    public Expression<Func<TEntity, object>> orderBy { get; private set; }

    public Expression<Func<TEntity, object>> orderByDescending { get; private set; }
 
    protected void AddOrderBy(Expression<Func<TEntity, object>> OrderByExpression) => orderBy = OrderByExpression;
    protected void AddOrderByDescending(Expression<Func<TEntity, object>> OrderByDescindingExpression) => 
        orderByDescending = OrderByDescindingExpression;
    #endregion

    #region Pagination
    public int Take { get; private set; }

    public int Skip { get; private set; }

    public bool IsPaginated { get; set; }

    protected void ApplyPaginations(int PageSize, int PageIndex)
    {
        IsPaginated = true;
        Take = PageSize;
        Skip = (PageIndex - 1) * PageSize;
    }
    #endregion
}
