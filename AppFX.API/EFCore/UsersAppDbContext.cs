using AppFX.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AppFX.API.EFCore
{
    public class UsersAppDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }

        public UsersAppDbContext(DbContextOptions<UsersAppDbContext> options) : base(options)
        {

        }

    }
}
