using System.ComponentModel.DataAnnotations;

namespace UserSystem.Application.DTO;

public class UserUpdatePasswordDTO
{
    [MinLength(8)]
    public string Password { get; set; } = null!;
}
