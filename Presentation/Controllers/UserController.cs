using Microsoft.AspNetCore.Mvc;
using UserSystem.Application.DTO;
using UserSystem.Application.Services;

namespace UserSystem.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(
    UserService service
) : Controller
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserRensponseDTO>>> GetAll() => Ok(await service.GetAll());
}
