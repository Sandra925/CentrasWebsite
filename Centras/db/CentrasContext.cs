using Centras.Models;
using Microsoft.EntityFrameworkCore;

namespace Centras.db
{
    public class CentrasContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public CentrasContext(DbContextOptions<CentrasContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) // Avoid reconfiguring if already set
            {
                optionsBuilder.UseSqlite("Data Source=C:\\Users\\K203082\\Desktop\\Centras\\Centras\\Centras\\db\\centras.db");
            }
        }
    }
}
