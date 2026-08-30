using Domain.Models.OrderModule;
using Shared.DTOs.OrderDTOs;
namespace ServiceImplementation.MappingProfiles;

public class OrderItemPictureUrlResolver : IValueResolver<OrderItem, OrderItemDto, string>
{
    public IConfiguration _configuration { get; }
    public OrderItemPictureUrlResolver(IConfiguration configuration)
    {
        _configuration = configuration;
    }  

    public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
    {      
        if (string.IsNullOrEmpty(source.Product.PictureUrl))
        {
            return string.Empty;
        }
        var pictureUrl = $"{_configuration.GetSection("Urls")["BaseUrl"]}{source.Product.PictureUrl}";
        return pictureUrl;
    }
}
