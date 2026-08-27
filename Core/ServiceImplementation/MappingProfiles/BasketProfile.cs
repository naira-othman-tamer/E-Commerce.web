using AutoMapper;
using Domain.Models.BasketModule;
using Domain.Models.ProductModule;
using Shared.DTOs.BasketModuleDTOs;
namespace ServiceImplementation.MappingProfiles;
public class BasketProfile : Profile
{
    public BasketProfile() {
        CreateMap<CustomerBasket, BasketDto>().ReverseMap();
        CreateMap<BasketItem,BasketItemDto>().ReverseMap();
    }
}
