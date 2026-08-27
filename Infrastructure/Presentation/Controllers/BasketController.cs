using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared;
using Shared.DTOs.BasketModuleDTOs;
using Shared.DTOs.ProductDTOs;
namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BasketController (IServiceManager _serviceManager) :ControllerBase
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
