using Domain.Models;

namespace Domain.Contracts;

public interface IGenericRepository<TEntity,Tkey> where TEntity : BaseEntity<Tkey>
{
    Task <IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(Tkey id);
    Task AddAsync(TEntity entity);
    void Update(TEntity entity); 
    Task Remove(TEntity entity);

}
