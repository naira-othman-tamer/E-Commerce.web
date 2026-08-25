using Domain.Models;
namespace Domain.Contracts;

public interface IGenericRepository<TEntity,Tkey> where TEntity : BaseEntity<Tkey>{
    Task <IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity,Tkey> specifications);
    Task <IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(Tkey id);
    Task<TEntity?> GetByIdAsync(ISpecifications<TEntity, Tkey> specifications);
    Task AddAsync(TEntity entity);
    void Update(TEntity entity); 
    Task Remove(TEntity entity);
    Task<int> CountAsync(ISpecifications<TEntity, Tkey> specifications);
}
