using Microsoft.EntityFrameworkCore;
using UserSystem.Domain.Entities;
using UserSystem.Domain.Interfaces;
using UserSystem.Infrastructure.Context;

namespace UserSystem.Infrastructure.Repositories;

public class UserRepository(
    AppDbContext repository
) : IUserRepository
{
    public async Task<IEnumerable<User>> GetAll() => await repository.Users.ToListAsync();

    public async Task Create(User user) => await repository.Users.AddAsync(user);

    public async Task<bool> ExistsByEmail(string email) => await repository.Users.AnyAsync(u => u.Email == email);

    public async Task SaveChanges() => await repository.SaveChangesAsync();
}
