using Domain.Models.OrderModule;
using Shared.DTOs.OrderDTOs;
namespace ServiceImplementation.MappingProfiles;
public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<AddressDto, OrderAddress>().ReverseMap(); 
        CreateMap<Order, OrderToReturnDto>()
            .ForMember(d=>d.DeliveryMethod,
            o=>o.MapFrom(src=>src.DeliveryMethod.ShortName));
        CreateMap<OrderItem, OrderItemDto>()
            .ForMember(d => d.ProductName,
            o => o.MapFrom(src => src.Product.ProductName))
            .ForMember(d => d.PictureUrl,
            o => o.MapFrom<OrderItemPictureUrlResolver>());

        CreateMap<DeliveryMethod, DeliveryMethodDTo>();
    }
}
