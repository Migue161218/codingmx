using codingmx.Shared;
using Microsoft.EntityFrameworkCore;

namespace codingmx.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }


        public DbSet<Cliente> Clientes { get; set; }
    }
}
