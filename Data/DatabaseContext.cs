using Countify.Models;
using Microsoft.EntityFrameworkCore;

namespace Countify.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }  
    }
}
