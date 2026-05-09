using Microsoft.EntityFrameworkCore;
using UserSystem.Domain.Entities;
using UserSystem.Domain.Interfaces;
using UserSystem.Infrastructure.Context;

namespace UserSystem.Infrastructure.Repositories;

public class UserRepository(
    AppDbContext repository
) : IUserRepository
{
    public async Task<IEnumerable<User>> GetAllAsync() => await repository.Users.ToListAsync();

    public async Task<User?> GetUserAsync(int id) => await repository.Users.FirstOrDefaultAsync(u => u.Id == id);

    public async Task CreateAsync(User user) => await repository.Users.AddAsync(user);

    public async Task<bool> ExistsByEmailAsync(string email) => await repository.Users.AnyAsync(u => u.Email == email);

    public async Task SaveChangesAsync() => await repository.SaveChangesAsync();

    public void Delete(User user) => repository.Users.Remove(user);
}
