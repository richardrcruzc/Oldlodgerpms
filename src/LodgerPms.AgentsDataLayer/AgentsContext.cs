using LodgerPms.Domain.Agents;
using Microsoft.EntityFrameworkCore;

namespace LodgerPms.AgentsDataLayer
{    
    public class AgentsContext : DbContext
    {
        public AgentsContext(DbContextOptions<AgentsContext> options)
      : base(options)
        { }

        public DbSet<Agent> Agents { get; private set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Agent>()
             .ToTable("Agents")
             .HasKey(x => x.Id);
        }
    }
}
