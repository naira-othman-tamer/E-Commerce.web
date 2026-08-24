using Domain.Contracts;
using Domain.Models;
using Persistence.Data;
namespace Persistence.Repositories;
/// <summary>
/// Implements the Unit of Work pattern by managing repositories
/// and coordinating database changes through a shared DbContext.
/// </summary>
public class UnitOfWork(StoreDbContext _dbContexxt) : IUnitOfWork {
    /// <summary>
    /// Stores repository instances by entity type name to reuse the same
    /// repository instance within the lifetime of the UnitOfWork.
    /// </summary>
    private readonly Dictionary<string, object> _repositories = []; // Collection Initializer
    /// <summary>
    /// Gets the generic repository for the specified entity type.
    /// If a repository already exists, the existing instance is returned.
    /// Otherwise, a new repository is created, stored, and returned.
    /// </summary>
    /// <typeparam name="TEntity">The entity type managed by the repository.</typeparam>
    /// <typeparam name="Tkey">The type of the entity's primary key.</typeparam>
    /// <returns>
    /// The existing or newly created generic repository for the specified entity type.
    /// </returns>
    public IGenericRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>{
        string typeName = typeof(TEntity).Name;
        if(_repositories.TryGetValue(typeName, out object? repository)
           && repository is IGenericRepository<TEntity, Tkey> repo){
            return repo;
        }  
        var newRepo = new GenericRepository<TEntity, Tkey>(_dbContexxt);
        _repositories[typeName] = newRepo;
        return newRepo;
       
    }
    /// <summary>
    /// Asynchronously persists all changes made through the shared DbContext
    /// to the database.
    /// </summary>
    /// <returns>
    /// The number of state entries written to the database.
    /// </returns>
    public async Task<int> SaveChangesAsync() => await _dbContexxt.SaveChangesAsync();
}
