
using LodgerPms.Domain.Rooms;
using Microsoft.EntityFrameworkCore;

namespace LodgerPms.RoomsDataLayer.Context
{
    public class RoomsContext : DbContext
    {
        public RoomsContext(DbContextOptions<RoomsContext> options)
      : base(options)
        { }
        //public DbSet<Department> Departments { get; private set; }

        public DbSet<BedType> BedTypes { get; private set; }
        public DbSet<RoomFacility> RoomFacilities { get; private set; }
        public DbSet<PropertyInfo> PropertyInfos { get; private set; }
        public DbSet<RoomGroup> RoomGroups { get; private set; }
        public DbSet<RoomExposure> RoomExposures { get; private set; }
        public DbSet<RoomInfo> RoomInfos { get; private set; }
        public DbSet<RoomLocation> RoomLocations { get; private set; }
        public DbSet<RoomStatus> RoomStatues { get; private set; }
        public DbSet<RoomType> RoomTypes { get; private set; }
        public DbSet<Status> Statues { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<lodgerpms.Domain.Common.FullName>();
            modelBuilder.Ignore<lodgerpms.Domain.Common.PostalAddress>();
            modelBuilder.Ignore<lodgerpms.Domain.Common.Telephone>();
            modelBuilder.Ignore<lodgerpms.Domain.Common.EmailAddress>();
            modelBuilder.Ignore<lodgerpms.Domain.Common.Person>();
            modelBuilder.Ignore<lodgerpms.Domain.Common.ContactInformation>();
            modelBuilder.Ignore<Department>();

            //     modelBuilder.Entity<RoomExposure>()
            //      .ToTable("RoomExposures")
            //      .HasKey(x => x.Id);

            //     modelBuilder.Entity<RoomFacility>()
            //    .ToTable("RoomFacilities")
            //    .HasKey(x => x.Id);

            //     modelBuilder.Entity<RoomGroup>()
            //   .ToTable("RoomGroups")
            //   .HasKey(x => x.Id);

            //     modelBuilder.Entity<RoomInfo>()
            //      .ToTable("RoomInfos")
            //      .HasKey(x => x.Id);

            //     modelBuilder.Entity<RoomLocation>()
            //   .ToTable("RoomLocations")
            //   .HasKey(x => x.Id);

            //     modelBuilder.Entity<RoomStatus>()
            //   .ToTable("RoomStatues")
            //   .HasKey(x => x.Id);

            //     modelBuilder.Entity<RoomType>()
            //  .ToTable("RoomTypes")
            //  .HasKey(x => x.Id);

            //     modelBuilder.Entity<Status>()
            //.ToTable("Statues")
            //.HasKey(x => x.Id);

        }
    }
}
