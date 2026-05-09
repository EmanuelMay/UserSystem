using UserSystem.Application.DTO;
using UserSystem.Domain.Interfaces;

namespace UserSystem.Application.Services;

public class UserService(
    IUserRepository repository
)
{
    public async Task<IEnumerable<UserRensponseDTO>> GetAll()
    {
        var users = await repository.GetAll();

        return users.Select(u => new UserRensponseDTO
        {
            Id = u.Id,
            Name = u.Name,
            Email = u.Email
        });
    }
}
