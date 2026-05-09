using UserSystem.Application.DTO;
using UserSystem.Domain.Entities;
using UserSystem.Domain.Exceptions;
using UserSystem.Domain.Interfaces;

namespace UserSystem.Application.Services;

public class UserService(
    IUserRepository repository
)
{
    public async Task<IEnumerable<UserResponseDTO>> GetAll()
    {
        var users = await repository.GetAll();

        return users.Select(u => new UserResponseDTO
        {
            Id = u.Id,
            Name = u.Name,
            Email = u.Email
        });
    }

    public async Task<UserResponseDTO> Create(UserCreateDTO userDTO)
    {
        if (await repository.ExistsByEmail(userDTO.Email))
            throw new EmailAlreadyExistException("email already exists");
        
        var user = new User(userDTO.Name, userDTO.Email, userDTO.Password);

        await repository.Create(user);
        await repository.SaveChanges();

        return new UserResponseDTO
        {
            Name = user.Name,
            Email = user.Email,
        };
    }
}
