using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DTOs.IdentityDTOs;
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

}
