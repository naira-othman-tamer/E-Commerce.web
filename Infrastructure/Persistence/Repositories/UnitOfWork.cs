using Domain.Contracts;
using Domain.Models;
using Persistence.Data;

namespace Persistence.Repositories;

public class UnitOfWork(StoreDbContext _dbContexxt) : IUnitOfWork
{
    private readonly Dictionary<string, object> _repositories = []; // Collection Initializer
    public IGenericRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>
    {
        string? typeName = typeof(TEntity).Name;
        //if (_repositories.ContainsKey(typeName))
            //return _repositories[typeName] as IGenericRepository<TEntity, Tkey>;
        if(_repositories.TryGetValue(typeName, out object? repository))
        {
            return repository as IGenericRepository<TEntity, Tkey>;
        }
        else // Create Object - Store In Deictionary - Return Object
        {
            var Repo = new GenericRepository<TEntity, Tkey>(_dbContexxt);
            //_repositories.Add(typeName, Repo);
            _repositories[typeName] = Repo;
            return Repo;
        }
    }

    public async Task<int> SaveChangesAsync() => await _dbContexxt.SaveChangesAsync();
}
