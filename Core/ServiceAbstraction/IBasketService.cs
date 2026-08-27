using Shared.DTOs.BasketModuleDTOs;
namespace ServiceAbstraction;
public interface IBasketService
{
    Task<BasketDto> GetBasketAsync(string Key);
    Task<BasketDto> CreateOrUpdateBasketAsync(BasketDto basket);
    Task<bool>DeleteBasketAsync(string Key);

}
