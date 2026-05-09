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
    public async Task<ActionResult<IEnumerable<UserResponseDTO>>> GetAllAsync() => Ok(await service.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<UserResponseDTO>> GetUserAsync(int id) => Ok(await service.GetUserAsync(id));

    [HttpPost]
    public async Task<ActionResult<UserResponseDTO>> CreateAsync(UserCreateDTO userDTO)
    {
        var response = await service.CreateAsync(userDTO);
        return Created($"user/{response.Id}", response);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<UserResponseDTO>> Delete(int id) => Ok(await service.Delete(id));
}
