using Shared.DTOs.IdentityDTOs;
namespace Shared.DTOs.OrderDTOs;
public class OrderRequestDto
{
    public string BasketId { get; set; }
    public int DeliveryMethodId { get; set; }
    public AddressDto Address { get; set; } = default!;
}
