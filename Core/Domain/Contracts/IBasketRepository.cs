using Domain.Models.BasketModule;

namespace Domain.Contracts;
public interface IBasketRepository
{
    Task<CustomerBasket> GetBasketAsync(string? Key);
    Task<CustomerBasket?> CreateOrUpdateBasketAsync(CustomerBasket basket, TimeSpan? TimeToLive=null);
    Task<bool> DeleteBasketAsync (string? id);
}
