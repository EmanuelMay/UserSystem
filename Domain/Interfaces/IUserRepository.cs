using UserSystem.Domain.Entities;

namespace UserSystem.Domain.Interfaces;

public interface IUserRepository
{
    public Task<IEnumerable<User>> GetAll();

    public Task Create(User user);

    public Task<bool> ExistsByEmail(string email);

    public Task SaveChanges();
}
