using Microsoft.EntityFrameworkCore;
using uCRUD.Server.Data.Models;

namespace uCRUD.Server.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
