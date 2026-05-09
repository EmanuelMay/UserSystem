using System.ComponentModel.DataAnnotations;

namespace UserSystem.Application.DTO;

public class UserRensponseDTO
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
}
