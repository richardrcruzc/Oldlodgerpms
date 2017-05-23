
namespace LodgerPms.Service.Departments.Api.Infrastructure
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    using LodgerPms.Departments.Api.Model;

    public class DepartmentContext : DbContext
    {
      
        public DepartmentContext(DbContextOptions<DepartmentContext> options) : base(options)
        { 
        }


        public DbSet<Department> Departments { get; set; }
        public DbSet<DepartmentGroup> DepartmentGroups { get; set; }
        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<FolioPattern> FolioPatterns { get; set; }
        public DbSet<LogBook> LogBooks { get; set; }
        public DbSet<MemberShip> MemberShips { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PackageDetail> PackageDetails { get; set; }
        public DbSet<Valet> Valets { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Department>(ConfigureDepartment);
            builder.Entity<DepartmentGroup>(ConfigureDepartmentGroup);
            builder.Entity<Deposit>(ConfigureDeposit);
            builder.Entity<FolioPattern>(ConfigureFolioPattern);
            builder.Entity<LogBook>(ConfigureLogBook);
            builder.Entity<MemberShip>(ConfigureMemberShip);
            builder.Entity<Package>(ConfigurePackage);
            builder.Entity<PackageDetail>(ConfigurePackageDetail);
            builder.Entity<Valet>(ConfigureValet);


        }

        void ConfigureDepartment(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");

            //builder.Property(ci => ci.Id)
            //    .ForSqlServerUseSequenceHiLo("catalog_hilo")
            //    .IsRequired();

            //builder.Property(ci => ci.Name)
            //    .IsRequired(true)
            //    .HasMaxLength(50);

            //builder.Property(ci => ci.Price)
            //    .IsRequired(true);

            //builder.Property(ci => ci.PictureUri)
            //    .IsRequired(false);

            //builder.HasOne(ci => ci.CatalogBrand)
            //    .WithMany()
            //    .HasForeignKey(ci => ci.CatalogBrandId);

            //builder.HasOne(ci => ci.CatalogType)
            //    .WithMany()
            //    .HasForeignKey(ci => ci.CatalogTypeId);
        }
        void ConfigureDepartmentGroup(EntityTypeBuilder<DepartmentGroup> builder)
        {
            builder.ToTable("DepartmentGroup");

            //builder.Property(ci => ci.Id)
            //    .ForSqlServerUseSequenceHiLo("catalog_hilo")
            //    .IsRequired();

            //builder.Property(ci => ci.Name)
            //    .IsRequired(true)
            //    .HasMaxLength(50);

            //builder.Property(ci => ci.Price)
            //    .IsRequired(true);

            //builder.Property(ci => ci.PictureUri)
            //    .IsRequired(false);

            //builder.HasOne(ci => ci.CatalogBrand)
            //    .WithMany()
            //    .HasForeignKey(ci => ci.CatalogBrandId);

            //builder.HasOne(ci => ci.CatalogType)
            //    .WithMany()
            //    .HasForeignKey(ci => ci.CatalogTypeId);
        }
        void ConfigureDeposit(EntityTypeBuilder<Deposit> builder)
        {
            builder.ToTable("Deposit");

            //builder.Property(ci => ci.Id)
            //    .ForSqlServerUseSequenceHiLo("catalog_hilo")
            //    .IsRequired();

            //builder.Property(ci => ci.Name)
            //    .IsRequired(true)
            //    .HasMaxLength(50);

            //builder.Property(ci => ci.Price)
            //    .IsRequired(true);

            //builder.Property(ci => ci.PictureUri)
            //    .IsRequired(false);

            //builder.HasOne(ci => ci.CatalogBrand)
            //    .WithMany()
            //    .HasForeignKey(ci => ci.CatalogBrandId);

            //builder.HasOne(ci => ci.CatalogType)
            //    .WithMany()
            //    .HasForeignKey(ci => ci.CatalogTypeId);
        }
        void ConfigureFolioPattern(EntityTypeBuilder<FolioPattern> builder)
        {
            builder.ToTable("FolioPattern");

            //builder.Property(ci => ci.Id)
            //    .ForSqlServerUseSequenceHiLo("catalog_hilo")
            //    .IsRequired();

            //builder.Property(ci => ci.Name)
            //    .IsRequired(true)
            //    .HasMaxLength(50);

            //builder.Property(ci => ci.Price)
            //    .IsRequired(true);

            //builder.Property(ci => ci.PictureUri)
            //    .IsRequired(false);

            //builder.HasOne(ci => ci.CatalogBrand)
            //    .WithMany()
            //    .HasForeignKey(ci => ci.CatalogBrandId);

            //builder.HasOne(ci => ci.CatalogType)
            //    .WithMany()
            //    .HasForeignKey(ci => ci.CatalogTypeId);
        }
        void ConfigureLogBook(EntityTypeBuilder<LogBook> builder)
        {
            builder.ToTable("LogBook");

            //builder.Property(ci => ci.Id)
            //    .ForSqlServerUseSequenceHiLo("catalog_hilo")
            //    .IsRequired();

            //builder.Property(ci => ci.Name)
            //    .IsRequired(true)
            //    .HasMaxLength(50);

            //builder.Property(ci => ci.Price)
            //    .IsRequired(true);

            //builder.Property(ci => ci.PictureUri)
            //    .IsRequired(false);

            //builder.HasOne(ci => ci.CatalogBrand)
            //    .WithMany()
            //    .HasForeignKey(ci => ci.CatalogBrandId);

            //builder.HasOne(ci => ci.CatalogType)
            //    .WithMany()
            //    .HasForeignKey(ci => ci.CatalogTypeId);
        }
        void ConfigureMemberShip(EntityTypeBuilder<MemberShip> builder)
        {
            builder.ToTable("MemberShip");

            //builder.Property(ci => ci.Id)
            //    .ForSqlServerUseSequenceHiLo("catalog_hilo")
            //    .IsRequired();

            //builder.Property(ci => ci.Name)
            //    .IsRequired(true)
            //    .HasMaxLength(50);

            //builder.Property(ci => ci.Price)
            //    .IsRequired(true);

            //builder.Property(ci => ci.PictureUri)
            //    .IsRequired(false);

            //builder.HasOne(ci => ci.CatalogBrand)
            //    .WithMany()
            //    .HasForeignKey(ci => ci.CatalogBrandId);

            //builder.HasOne(ci => ci.CatalogType)
            //    .WithMany()
            //    .HasForeignKey(ci => ci.CatalogTypeId);
        }
        void ConfigurePackage(EntityTypeBuilder<Package> builder)
        {
            builder.ToTable("Package");

            //builder.Property(ci => ci.Id)
            //    .ForSqlServerUseSequenceHiLo("catalog_hilo")
            //    .IsRequired();

            //builder.Property(ci => ci.Name)
            //    .IsRequired(true)
            //    .HasMaxLength(50);

            //builder.Property(ci => ci.Price)
            //    .IsRequired(true);

            //builder.Property(ci => ci.PictureUri)
            //    .IsRequired(false);

            //builder.HasOne(ci => ci.CatalogBrand)
            //    .WithMany()
            //    .HasForeignKey(ci => ci.CatalogBrandId);

            //builder.HasOne(ci => ci.CatalogType)
            //    .WithMany()
            //    .HasForeignKey(ci => ci.CatalogTypeId);
        }
        void ConfigurePackageDetail(EntityTypeBuilder<PackageDetail> builder)
        {
            builder.ToTable("PackageDetail");

            //builder.Property(ci => ci.Id)
            //    .ForSqlServerUseSequenceHiLo("catalog_hilo")
            //    .IsRequired();

            //builder.Property(ci => ci.Name)
            //    .IsRequired(true)
            //    .HasMaxLength(50);

            //builder.Property(ci => ci.Price)
            //    .IsRequired(true);

            //builder.Property(ci => ci.PictureUri)
            //    .IsRequired(false);

            //builder.HasOne(ci => ci.CatalogBrand)
            //    .WithMany()
            //    .HasForeignKey(ci => ci.CatalogBrandId);

            //builder.HasOne(ci => ci.CatalogType)
            //    .WithMany()
            //    .HasForeignKey(ci => ci.CatalogTypeId);
        }
        void ConfigureValet(EntityTypeBuilder<Valet> builder)
        {
            builder.ToTable("Valet");

            //builder.Property(ci => ci.Id)
            //    .ForSqlServerUseSequenceHiLo("catalog_hilo")
            //    .IsRequired();

            //builder.Property(ci => ci.Name)
            //    .IsRequired(true)
            //    .HasMaxLength(50);

            //builder.Property(ci => ci.Price)
            //    .IsRequired(true);

            //builder.Property(ci => ci.PictureUri)
            //    .IsRequired(false);

            //builder.HasOne(ci => ci.CatalogBrand)
            //    .WithMany()
            //    .HasForeignKey(ci => ci.CatalogBrandId);

            //builder.HasOne(ci => ci.CatalogType)
            //    .WithMany()
            //    .HasForeignKey(ci => ci.CatalogTypeId);
        }


        
    }
}