using Microsoft.EntityFrameworkCore;
using LodgerPms.Domain.Bookings;
using LodgerPms.Domain.Rooms;
using LodgerPms.Domain.Shared;
using LodgerPms.Domain.Agents;

namespace LodgerPms.Persistence.FaceCover
{
    public class EFDomainDbContext : DbContext
    {
        public EFDomainDbContext(DbContextOptions<EFDomainDbContext> options)
      : base(options)
        { }

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
            modelBuilder.Entity<GuestInfo> ()
             .ToTable("GuestInfo")
             .HasKey(x => x.Id);

            modelBuilder.Entity<Rate>()
             .ToTable("Rate")
             .HasKey(x => x.Id);

            modelBuilder.Entity<BedType>()
               .ToTable("BedType")
               .HasKey(x =>  x.Id);


            modelBuilder.Entity<PropertyInfo>()
             .ToTable("PropertyInfo")
             .HasKey(x => x.Id);

            modelBuilder.Entity<RoomExposure>()
             .ToTable("RoomExposure")
             .HasKey(x => x.Id);

            modelBuilder.Entity<RoomFacility>()
             .ToTable("RoomFacility")
             .HasKey(x => x.Id);

            modelBuilder.Entity<RoomInfo>()
             .ToTable("RoomInfo")
             .HasKey(x=>new  { x.Id, x.RoomLocationId, x.RoomTypeId, x.BedTypeId });

            modelBuilder.Entity<RoomInfo>()
                .HasOne(rt => rt.RoomType)
                .WithMany(r => r.RoomInfoList);

            modelBuilder.Entity<RoomInfo>()
                .HasOne(rt => rt.BedType)
                .WithMany(r => r.RoomInfoList);

            modelBuilder.Entity<RoomInfo>()
                .HasOne(rt => rt.RoomLocation)
                .WithMany(r => r.RoomInfoList);


            modelBuilder.Entity<RoomLocation>()
             .ToTable("RoomLocation")
             .HasKey(x => x.Id);

            modelBuilder.Entity<RoomStatus>()
             .ToTable("RoomStatus")
             .HasKey(x => x.Id);

            modelBuilder.Entity<RoomStatus>()
                .HasOne(x => x.Booking)
                .WithOne(x => x.RoomStatus)
                .HasForeignKey<Booking>(f=>f.RoomStatusId);



            modelBuilder.Entity<RoomGroup>()
        .ToTable("RoomGroup")
        .HasKey(x => x.Id);

            modelBuilder.Entity<RoomType>()
             .ToTable("RoomType")
             .HasKey(x => new { x.Id, x.RoomGroupId });

            modelBuilder.Entity<RoomType>()
                .HasOne(g => g.Group)
                .WithMany(i => i.RoomTypeList)
                .HasForeignKey(f => f.RoomGroupId);

            modelBuilder.Entity<Status>()
          .ToTable("Status")
          .HasKey(x => x.Id);



        }
    }
}
