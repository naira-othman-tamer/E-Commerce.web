using Domain.Contracts;
using Domain.Models.BasketModule;
using StackExchange.Redis;
using System.Text.Json;

namespace Persistence.Repositories;

public class BasketRepository(IConnectionMultiplexer connection) : IBasketRepository
{
    private readonly IDatabase _database = connection.GetDatabase();
    public async Task<CustomerBasket?> CreateOrUpdateBasketAsync(CustomerBasket basket, TimeSpan? TimeToLive = null)
    {
        string? JsonBasket =JsonSerializer.Serialize(basket);
       bool isCreatedOrUpdated = await _database
            .StringSetAsync(basket.Id, JsonBasket, TimeToLive ?? TimeSpan.FromDays(30));
        return isCreatedOrUpdated ? await GetBasketAsync(basket.Id) : null;
    }

    public async Task<bool> DeleteBasketAsync(string? id) => await _database.KeyDeleteAsync(id);

    public async Task<CustomerBasket> GetBasketAsync(string? Key)
    {
        RedisValue Basket = await _database.StringGetAsync(Key);
        if (Basket.IsNullOrEmpty)
        {
            return null;
        }
        else
        {
            return JsonSerializer.Deserialize<CustomerBasket>((string)Basket!)!;
        }
    }
}
