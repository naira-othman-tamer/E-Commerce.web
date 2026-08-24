using Domain.Models;
namespace Domain.Contracts;
/// <summary>
/// Defines the Unit of Work contract for managing repositories
/// and committing changes to the database.
/// </summary>
public interface IUnitOfWork{
    /// <summary>
    /// Gets the generic repository for the specified entity type.
    /// If a repository instance already exists, the existing instance is returned.
    /// Otherwise, a new repository is created, stored, and returned.
    /// </summary>
    /// <typeparam name="TEntity">The entity type managed by the repository.</typeparam>
    /// <typeparam name="Tkey">The type of the entity's primary key.</typeparam>
    /// <returns>
    /// The existing or newly created generic repository.
    /// </returns>
    IGenericRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>;
    /// <summary>
    /// Asynchronously commits all pending changes to the database.
    /// </summary>
    /// <returns>
    /// The number of state entries written to the database.
    /// </returns>
    Task<int> SaveChangesAsync();
}
