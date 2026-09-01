using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DTOs.OrderDTOs;
namespace Presentation.Controllers;

public class OrderController (IServiceManager _serviceManager) :ApiBaseController
{
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<OrderToReturnDto>> CreateOrder (OrderRequestDto orderRequest)
    {
       var order = await _serviceManager.OrderService.CreateOrderAsync(orderRequest, GetEmailFromToken());
        return Ok (order);
    }

    [HttpGet()]
    public async Task<ActionResult<IEnumerable<DeliveryMethodDTo>> GetAllDeliveryMethods()
    {

    }

    [HttpGet()]
    public async Task<ActionResult<IEnumerable<OrderToReturnDto>>> GetAllOrders()
    {

    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<OrderToReturnDto>> GetOrderById(Guid Id)
    {

    }
}
