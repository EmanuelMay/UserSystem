using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace UserSystem.Domain.Entities;

public class User
{
    private User() { }

    public User(string name, string email, string password)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("name cannot be empty");
        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            throw new ArgumentException("email invalid");
        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("password cannot be empty");

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

    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("name cannot be empty");
        
        Name = name;
    }

    public void UpdateEmail(string email)
    {
        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            throw new ArgumentException("email invalid");
        
        Email = email;
    }

    public void UpdatePassword(string password)
    {
        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("password cannot be empty");
        
        Password = password;
    }
}
