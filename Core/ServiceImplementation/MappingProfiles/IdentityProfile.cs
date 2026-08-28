namespace ServiceImplementation.MappingProfiles;
public class IdentityProfile : Profile
{
    public IdentityProfile()
    {
        CreateMap<Address,AddressDto>().ReverseMap();
    }
}
