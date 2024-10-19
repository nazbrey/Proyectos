using Microsoft.EntityFrameworkCore;
using UsersService.Users.Domain.Entities;

namespace UsersService.Users.Infrastructure.Data
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd(); // Indica que el Id se generará automáticamente
        }
    }
}

