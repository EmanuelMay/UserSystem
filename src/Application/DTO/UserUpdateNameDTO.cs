using System.ComponentModel.DataAnnotations;

namespace UserSystem.Application.DTO;

public class UserUpdateNameDTO
{
    [Required]
    public string Name { get; set; } = null!;
}
