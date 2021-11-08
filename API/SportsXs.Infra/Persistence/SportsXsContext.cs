using Microsoft.EntityFrameworkCore;
using SportsXs.Domain.Entities;
using SportsXs.Infra.Mappings;

namespace SportsXs.Infra.Persistence
{
    public class SportsXsContext : DbContext
    {
        public SportsXsContext(DbContextOptions<SportsXsContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Phones> Phones { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new PhonesMap());
        }

    }
}
