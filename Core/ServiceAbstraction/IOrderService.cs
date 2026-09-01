using Shared.DTOs.OrderDTOs;
namespace ServiceAbstraction;
public interface IOrderService
{
    Task<OrderToReturnDto> CreateOrderAsync(OrderRequestDto requestDto,string Email);
    Task<IEnumerable<DeliveryMethodDTo>> GetDeliveryMethodsAsync();
    Task<IEnumerable<OrderToReturnDto>> GetAllOrdersAsync(string Email);
    Task<OrderToReturnDto> GetOrdersByIdAsync(Guid Id);
}
