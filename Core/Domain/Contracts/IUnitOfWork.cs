using Domain.Models;
namespace Domain.Contracts;

public interface IUnitOfWork{
    /// <summary>
    /// start Get Type Name , if Object already Created return it , it not create a new Object - Use Dictionary
    /// </summary>
    /// <typeparam EntityType="TEntity"></typeparam>
    /// <typeparam EntityKeyType="Tkey"></typeparam>
    /// <returns></returns>
    IGenericRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>;
    Task<int> SaveChangesAsync();
}
