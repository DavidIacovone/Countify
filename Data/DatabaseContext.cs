using Countify.Models;
using Microsoft.EntityFrameworkCore;

namespace Countify.Data
{
    public class DatabaseContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DatabaseContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("MainDatabase"));
        }

        public DbSet<User> Users { get; set; }  
    }
}
