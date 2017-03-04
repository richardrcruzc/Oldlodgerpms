
using System.IO;
using LodgerPms.DepartmentsDataLayer.Mappings;
using LodgerPms.Domain.Departments.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LodgerPms.DepartmentsDataLayer.Extensions;
using System.Linq;

namespace LodgerPms.DepartmentsDataLayer.Context
{

    public class DepartmentsReadOnlyContext : DbContext
    {
        //  public DepartmentsContext(DbContextOptions<DepartmentsContext> options)
        //: base(options)
        //  { }


        public DepartmentsReadOnlyContext()
        {
            _departments = base.Set<Department>();
            _deposits = base.Set<Deposit>();
            _folioPatterns = base.Set<FolioPattern>();
            _logBooks = base.Set<LogBook>();
            _memberShips = base.Set<MemberShip>();
            _packageDetails = base.Set<PackageDetail>();
            _valets = base.Set<Valet>();
        }

        private readonly DbSet<Department> _departments = null;
        private readonly DbSet<Deposit> _deposits = null;
        private readonly DbSet<FolioPattern> _folioPatterns = null;
        private readonly DbSet<LogBook> _logBooks = null;
        private readonly DbSet<MemberShip> _memberShips = null;
        private readonly DbSet<PackageDetail> _packageDetails = null;
        private readonly DbSet<Valet> _valets = null;
        public IQueryable<Department> Departments { get { return _departments; }}
        public IQueryable<Deposit> Deposits { get { return _deposits; } }
        public IQueryable<FolioPattern> FolioPatterns { get { return _folioPatterns; } }
        public IQueryable<LogBook> LogBooks { get { return _logBooks; } }
        public IQueryable<MemberShip> MemberShips { get { return _memberShips; } }
        public IQueryable<PackageDetail> PackageDetails { get { return _packageDetails; } }
        public IQueryable<Valet> Valets { get { return _valets; } }




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
