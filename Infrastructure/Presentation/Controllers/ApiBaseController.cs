using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApiBaseController () :ControllerBase
{
}
