using System.ComponentModel.DataAnnotations;

namespace UserSystem.Domain.Entities;

public class User
{
    private User() { }

    public User(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }

    public int Id { get; private set; }

    [StringLength(150)]
    public string Name { get; private set; } = null!;

    [StringLength(255)]
    public string Email { get; private set; } = null!;

    [StringLength(255)]
    public string Password { get; private set; } = null!;
}
