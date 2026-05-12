using System.ComponentModel.DataAnnotations;

namespace UserSystem.Application.DTO;

public class UserUpdateEmailDTO
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
}
