using Shared.DTOs.IdentityDTOs;

namespace Shared.DTOs.OrderDTOs;
public class OrderToReturnDto
{
    public Guid Id { get; set; }
    public string UserEmail { get; set; } = default!;
    public DateTimeOffset OrderDate { get; set; }
    public AddressDto Address { get; set; } = default!;
    public string DeliveryMethod { get; set; } = default!;
    public string Status { get; set; } = default!;
    public ICollection<OrderItemDto> Items { get; set; } = [];
    public decimal SubTotal { get; set; } 
    public decimal Total { get; set; }
}
