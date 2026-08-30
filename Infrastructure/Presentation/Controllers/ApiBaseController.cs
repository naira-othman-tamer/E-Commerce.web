using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using System.Security.Claims;
namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiBaseController () :ControllerBase
{
    protected string GetEmailFromToken() => User.FindFirstValue(ClaimTypes.Email)!; 
}
