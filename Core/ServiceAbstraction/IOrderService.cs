using Shared.DTOs.OrderDTOs;
namespace ServiceAbstraction;
public interface IOrderService
{
    Task<OrderToReturnDto> CreateOrderAsync(OrderRequestDto requestDto,string Email);
}
