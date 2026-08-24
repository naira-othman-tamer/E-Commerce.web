using Domain.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Helper;
namespace Persistence.Repositories;

public class GenericRepository<TEntity, Tkey> (StoreDbContext _dbContext) :
    IGenericRepository<TEntity, Tkey>
    where TEntity : BaseEntity<Tkey> {
    public async Task AddAsync(TEntity entity) => await _dbContext.Set<TEntity>().AddAsync(entity);
    public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbContext.Set<TEntity>().ToListAsync();

    public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity, Tkey> specifications)
    {
        return await SpecificationEvaluator
              .CreateQuery(_dbContext.Set<TEntity>(), specifications)
              .ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(Tkey id) => await _dbContext.Set<TEntity>().FindAsync(id);

    public async Task<TEntity?> GetByIdAsync(ISpecifications<TEntity, Tkey> specifications)
    {
        return await SpecificationEvaluator
            .CreateQuery(_dbContext.Set<TEntity>(), specifications)
            .FirstOrDefaultAsync();
    }

    public async Task Remove(TEntity entity) => _dbContext.Set<TEntity>().Remove(entity);
    public void Update(TEntity entity) => _dbContext.Set<TEntity>().Update(entity);
}
