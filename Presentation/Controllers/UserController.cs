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
    [HttpPost]
    public async Task<ActionResult<UserResponseDTO>> CreateAsync([FromBody] UserCreateDTO userDTO)
    {
        var response = await service.CreateAsync(userDTO);
        return Created($"user/{response.Id}", response);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserResponseDTO>>> GetAllAsync() 
        => Ok(await service.GetAllAsync());

    [HttpGet("{id:int}")]
    public async Task<ActionResult<UserResponseDTO>> GetUserAsync(int id) 
        => Ok(await service.GetUserAsync(id));

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<UserResponseDTO>> Delete(int id)
        => Ok(await service.Delete(id));

    [HttpPatch("{id:int}/name")]
    public async Task<ActionResult<UserResponseDTO>> UpdateName(
        int id,
        [FromBody] UserUpdateNameDTO updateDTO
    ) 
        => Ok(await service.UpdateName(id, updateDTO));
    
    [HttpPatch("{id:int}/email")]
    public async Task<ActionResult<UserResponseDTO>> UpdateEmail(
        int id,
        [FromBody] UserUpdateEmailDTO updateDTO
    )
        => Ok(await service.UpdateEmail(id, updateDTO));
    
    [HttpPatch("{id:int}/password")]
    public async Task<ActionResult<UserResponseDTO>> UpdatePassword(
        int id,
        [FromBody] UserUpdatePasswordDTO updateDTO
    )
        => Ok(await service.UpdatePassword(id, updateDTO));
}
