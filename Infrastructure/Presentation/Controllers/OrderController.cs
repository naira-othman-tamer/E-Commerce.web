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

    [HttpGet("DeliveryMethods")]
    public async Task<ActionResult<IEnumerable<DeliveryMethodDTo>>> GetAllDeliveryMethods()
    {
        var deliveryMethods=  await _serviceManager.OrderService.GetDeliveryMethodsAsync();
        return Ok(deliveryMethods);
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderToReturnDto>>> GetAllOrders()
    {
        var orders = await _serviceManager.OrderService.GetAllOrdersAsync(GetEmailFromToken());
        return Ok(orders);
    }

    [HttpGet("{Id:guid}")]
    public async Task<ActionResult<OrderToReturnDto>> GetOrderById(Guid Id)
    {
        var order = await _serviceManager.OrderService.GetOrdersByIdAsync(Id);
        return Ok(order);
    }
}
