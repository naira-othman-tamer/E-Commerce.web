using Domain.Models;
namespace Domain.Contracts;

public interface IUnitOfWork{
    /// <summary>
    /// Gets the generic repository for the specified entity type.
    /// If a repository instance already exists in the dictionary, it returns the existing instance.
    /// Otherwise, it creates a new repository, stores it in the dictionary, and returns it.
    /// </summary>
    /// <typeparam name="TEntity">The entity type managed by the repository.</typeparam>
    /// <typeparam name="Tkey">The type of the entity's key.</typeparam>
    /// <returns>
    /// The existing or newly created <see cref="IGenericRepository{TEntity, Tkey}"/> instance.
    /// </returns>
    IGenericRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>;
    Task<int> SaveChangesAsync();
}
