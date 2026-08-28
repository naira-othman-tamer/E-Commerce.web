using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DTOs.BasketModuleDTOs;
namespace Presentation.Controllers;

public class BasketController (IServiceManager _serviceManager) :ApiBaseController
{
    [HttpGet]
    public async Task <ActionResult<BasketDto>> GetBasket([FromQuery]string Key)
    {
        var basket= await _serviceManager.BasketService.GetBasketAsync(Key);
        return Ok(basket);
    }

    [HttpPost]
    public async Task<ActionResult<BasketDto>> CreateOrUpdateBasket(BasketDto basket)
    {
        var createdOrUpdatedBasket = await _serviceManager
                                      .BasketService
                                     .CreateOrUpdateBasketAsync(basket);
        return Ok(basket);
    }

    [HttpDelete("{Key}")]
    public async Task<ActionResult<bool>> DeleteBasket(string key)
    {
        var result =await _serviceManager.BasketService.DeleteBasketAsync(key);
        return Ok(result);
    }
}
