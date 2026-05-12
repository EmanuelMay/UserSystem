using Microsoft.EntityFrameworkCore;
using UserSystem.Domain.Entities;

namespace UserSystem.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; private set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<User>()
            .ToTable("users");

        mb.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
    }
}
