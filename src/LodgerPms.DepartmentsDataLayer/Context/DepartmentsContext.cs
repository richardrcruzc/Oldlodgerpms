
using System.IO;
using LodgerPms.DepartmentsDataLayer.Mappings;
using LodgerPms.Domain.Departments.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LodgerPms.DepartmentsDataLayer.Extensions;

namespace LodgerPms.DepartmentsDataLayer.Context
{

    public class DepartmentsContext : DbContext
    {
      //  public DepartmentsContext(DbContextOptions<DepartmentsContext> options)
      //: base(options)
      //  { }
        public DbSet<Department> Departments { get; private set; }

        public DbSet<DepartmentGroup> DepartmentGroups { get; private set; }
        public DbSet<Deposit> Deposits { get; private set; }
        public DbSet<FolioPattern> FolioPatterns { get; private set; }
        public DbSet<LogBook> LogBooks { get; private set; }
        public DbSet<MemberShip> MemberShips { get; private set; }
        public DbSet<Package> Packages { get; private set; }
        public DbSet<PackageDetail> PackageDetails { get; private set; }
        public DbSet<Valet> Valets { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Ignore<lodgerpms.Domain.Common.FullName>();

            modelBuilder.AddConfiguration(new DepartmentMap());

            base.OnModelCreating(modelBuilder);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get the configuration from the app settings
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // define the database to use
            optionsBuilder.UseSqlServer(config.GetConnectionString("LodgerPmsDatabase"));
        }
        }
}
