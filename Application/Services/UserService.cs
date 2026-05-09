using UserSystem.Application.DTO;
using UserSystem.Domain.Entities;
using UserSystem.Domain.Exceptions;
using UserSystem.Domain.Interfaces;

namespace UserSystem.Application.Services;

public class UserService(
    IUserRepository repository
)
{
    public async Task<IEnumerable<UserResponseDTO>> GetAllAsync()
    {
        var users = await repository.GetAllAsync();

        return users.Select(u => new UserResponseDTO
        {
            Id = u.Id,
            Name = u.Name,
            Email = u.Email
        });
    }

    public async Task<UserResponseDTO> GetUserAsync(int id)
    {
        var user = await repository.GetUserAsync(id);

        if (user is null)
            throw new UserNotFoundException("user not found");
        
        return new UserResponseDTO()
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        };
    }

    public async Task<UserResponseDTO> CreateAsync(UserCreateDTO userDTO)
    {
        if (await repository.ExistsByEmailAsync(userDTO.Email))
            throw new EmailAlreadyExistException("email already exists");
        
        var user = new User(userDTO.Name, userDTO.Email, userDTO.Password);

        await repository.CreateAsync(user);
        await repository.SaveChangesAsync();

        return new UserResponseDTO
        {
            Name = user.Name,
            Email = user.Email,
        };
    }
}
