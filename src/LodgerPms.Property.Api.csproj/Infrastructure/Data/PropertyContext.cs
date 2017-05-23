
using LodgerPms.Domain.Rooms;
using LodgerPms.Domain.SeedWork;
using LodgerPms.Property.Api.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LodgerPms.Property.Api.Infrastructure.Data
{
    public class PropertyContext : DbContext, IUnitOfWork
    {
        const string DEFAULT_SCHEMA = "Properties";
        private readonly IMediator _mediator;

        public PropertyContext(DbContextOptions options, IMediator mediator) : base(options)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        
        public DbSet<BedType> BedTypes { get; set; }
        public DbSet<PropertyInfo> PropertyInfos { get; set; } 

        public DbSet<RoomExposure> RoomExposures { get; set; }
        public DbSet<RoomFacility> RoomFacilitys { get; set; }
        public DbSet<RoomGroup> RoomGroups { get; set; }
        public DbSet<RoomInfo> RoomInfos { get; set; }
        public DbSet<RoomLocation> RoomLocations { get; set; }
        public DbSet<RoomStatus> RoomStatuss { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(ConfigureAddress);

            // modelBuilder.Entity<ClientRequest>(ConfigureRequests);
        }
        void ConfigureAddress(EntityTypeBuilder<Address> addressConfiguration)
        {
            addressConfiguration.ToTable("address", DEFAULT_SCHEMA);

            // DDD Pattern comment: Implementing the Address Id as "Shadow property"
            // becuase the Address is a Value-Object (VO) and an Id (Identity) is not desired for a VO
            // EF Core just needs the Id so it is capable to store it in a database table
            // See: https://docs.microsoft.com/en-us/ef/core/modeling/shadow-properties 
            addressConfiguration.Property<int>("Id")
                .IsRequired();

            addressConfiguration.HasKey("Id");
        }


        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // Dispatch Domain Events collection. 
            // Choices:
            // A) Right BEFORE committing data (EF SaveChanges) into the DB will make a single transaction including  
            // side effects from the domain event handlers which are using the same DbContext with "InstancePerLifetimeScope" or "scoped" lifetime
            // B) Right AFTER committing data (EF SaveChanges) into the DB will make multiple transactions. 
            // You will need to handle eventual consistency and compensatory actions in case of failures in any of the Handlers. 
            await _mediator.DispatchDomainEventsAsync(this);


            // After executing this line all the changes (from the Command Handler and Domain Event Handlers) 
            // performed throught the DbContext will be commited
            var result = await base.SaveChangesAsync();

            return true;
        }
    }
}
