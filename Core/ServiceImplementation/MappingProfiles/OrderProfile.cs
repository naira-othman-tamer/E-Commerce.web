using Domain.Models.OrderModule;

namespace ServiceImplementation.MappingProfiles;
public class OrderProfile :Profile
{
    public OrderProfile()
    {
        CreateMap<AddressDto, OrderAddress>(); 
    }
}
