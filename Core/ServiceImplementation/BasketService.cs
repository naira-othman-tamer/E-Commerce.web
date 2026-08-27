namespace ServiceImplementation;
public class BasketService(IBasketRepository _basketRepository, IMapper _mapper) : IBasketService
{
    public async Task<BasketDto> CreateOrUpdateBasketAsync(BasketDto basket)
    {
         var custometBasket =_mapper.Map<BasketDto,CustomerBasket>(basket);
         var IsCreatedOrUpdated = await _basketRepository
                                             .CreateOrUpdateBasketAsync(custometBasket);
        if(IsCreatedOrUpdated is not null)
        {
            return _mapper.Map<CustomerBasket, BasketDto>(IsCreatedOrUpdated);
            //return await GetBasketAsync(basket.Id);
        }
        throw new Exception("Cannot Create Or Update Basket Now");
    }

    public async Task<BasketDto> GetBasketAsync(string Key)
    {
        var basket= await _basketRepository.GetBasketAsync(Key);
        if (basket is not null)
        {
            _mapper.Map<CustomerBasket, BasketDto>(basket);
        }
        throw new BasketNotFoundException(Key);
    }

    public async Task<bool> DeleteBasketAsync(string Key) => 
        await _basketRepository.DeleteBasketAsync(Key);
}
