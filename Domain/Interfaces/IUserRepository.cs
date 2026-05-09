using UserSystem.Domain.Entities;

namespace UserSystem.Domain.Interfaces;

public interface IUserRepository
{
    public Task<IEnumerable<User>> GetAll();
}
