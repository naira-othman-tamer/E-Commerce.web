using Domain.Contracts;
using Domain.Models;
using Persistence.Data;
namespace Persistence.Repositories;
public class UnitOfWork(StoreDbContext _dbContexxt) : IUnitOfWork {
    private readonly Dictionary<string, object> _repositories = []; // Collection Initializer
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
    public async Task<int> SaveChangesAsync() => await _dbContexxt.SaveChangesAsync();
}
