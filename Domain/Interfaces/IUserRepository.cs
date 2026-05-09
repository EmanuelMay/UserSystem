using UserSystem.Domain.Entities;

namespace UserSystem.Domain.Interfaces;

public interface IUserRepository
{
    public Task<IEnumerable<User>> GetAllAsync();

    public Task<User?> GetUserAsync(int id);

    public Task CreateAsync(User user);

    public Task<bool> ExistsByEmailAsync(string email);

    public Task SaveChangesAsync();

    public void Delete(User user);
}
