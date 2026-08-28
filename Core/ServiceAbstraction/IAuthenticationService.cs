using Shared.DTOs.IdentityDTOs;
namespace ServiceAbstraction;
public interface IAuthenticationService
{
    Task<UserDto> LoginAsync(LoginDto loginDto);
    Task<UserDto> Register(RegisterDto registerDto);
    Task<bool> CheckEmailAsync(string Email);
    Task<AddressDto> GetCurrentUserAddressAsync(string Email);
    Task<AddressDto> UpdateCurrentUserAddressAsync(AddressDto UpdatedAddress,string Email);
    Task<UserDto> GetCurrentUserAsync(string Email);
}
