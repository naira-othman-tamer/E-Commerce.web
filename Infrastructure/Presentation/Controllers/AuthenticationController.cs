using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DTOs.IdentityDTOs;
using System.Security.Claims;
namespace Presentation.Controllers;
public class AuthenticationController(IServiceManager _serviceManager) : ApiBaseController
{
    [HttpPost("Login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var user = await _serviceManager.AuthenticationService.LoginAsync(loginDto);
        return Ok(user);
    }

    [HttpPost("Register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        var user = await _serviceManager.AuthenticationService.Register(registerDto);
        return Ok(user);
    }

    [HttpGet("CheckEmail")] 
    public async Task<ActionResult<bool>> CheckEmail(string email)
    {
       var result = await _serviceManager.AuthenticationService.CheckEmailAsync(email);
        return Ok(result);
    }

    [Authorize]
    [HttpGet("CurrentUser")]
    public async Task<ActionResult<UserDto>> GetCurrentUser()
    {
       var user = await _serviceManager.AuthenticationService.GetCurrentUserAsync(GetEmailFromToken());
        return Ok(user);
    }

    [Authorize]
    [HttpGet("CurrentUserAddress")]
    public async Task<ActionResult<AddressDto>> GetCurrentUserAddress()
    {
        var address= await _serviceManager.AuthenticationService.GetCurrentUserAddressAsync(GetEmailFromToken());
        return Ok(address);
    }

    [Authorize]
    [HttpPut("Address")]
    public async Task<ActionResult<AddressDto>> UpdateUserAddress(AddressDto addressDto) 
    {
        var updatedAddress= await _serviceManager.AuthenticationService
                    .UpdateCurrentUserAddressAsync(addressDto, GetEmailFromToken());
        return Ok(updatedAddress);
    }
}
