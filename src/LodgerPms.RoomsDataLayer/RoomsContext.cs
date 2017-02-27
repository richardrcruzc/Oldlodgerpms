
using LodgerPms.Domain.Rooms;
using Microsoft.EntityFrameworkCore;

namespace LodgerPms.RoomsDataLayer
{     
    public class RoomsContext : DbContext
    {
        public RoomsContext(DbContextOptions<RoomsContext> options)
      : base(options)
        { }

        public DbSet<RoomInfo> RoomInfos { get; private set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Ignore<>
            modelBuilder.Entity<RoomExposure>()
             .ToTable("RoomExposures")
             .HasKey(x => x.Id);

            modelBuilder.Entity<RoomFacility>()
           .ToTable("RoomFacilities")
           .HasKey(x => x.Id);

            modelBuilder.Entity<RoomGroup>()
          .ToTable("RoomGroups")
          .HasKey(x => x.Id);

            modelBuilder.Entity<RoomInfo>()
             .ToTable("RoomInfos")
             .HasKey(x => x.Id);

            modelBuilder.Entity<RoomLocation>()
          .ToTable("RoomLocations")
          .HasKey(x => x.Id);

            modelBuilder.Entity<RoomStatus>()
          .ToTable("RoomStatues")
          .HasKey(x => x.Id);

            modelBuilder.Entity<RoomType>()
         .ToTable("RoomTypes")
         .HasKey(x => x.Id);

            modelBuilder.Entity<Status>()
       .ToTable("Statues")
       .HasKey(x => x.Id);

        }
    }
}
