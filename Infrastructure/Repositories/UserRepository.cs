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
}
