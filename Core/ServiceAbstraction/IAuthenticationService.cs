using Shared.DTOs.IdentityDTOs;
namespace ServiceAbstraction;
public interface IAuthenticationService
{
    Task<UserDto> LoginAsync(LoginDto loginDto);
    Task<UserDto> Register(RegisterDto registerDto);
}
