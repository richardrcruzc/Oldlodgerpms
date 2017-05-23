using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LodgerPms.Service.Departments.Api.Infrastructure;
using LodgerPms.Departments.Api.Model;

namespace LodgerPms.Departments.Api.Migrations
{
    [DbContext(typeof(DepartmentContext))]
    [Migration("20170520001451_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LodgerPms.Departments.Api.Model.Department", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<bool>("ApplyTax");

                    b.Property<string>("DepartmentGroupId");

                    b.Property<int>("DepartmentType");

                    b.Property<string>("Description");

                    b.Property<string>("PackageId");

                    b.Property<decimal>("Percentage");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentGroupId");

                    b.HasIndex("PackageId");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("LodgerPms.Departments.Api.Model.DepartmentGroup", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("DepartmentGroup");
                });

            modelBuilder.Entity("LodgerPms.Departments.Api.Model.Deposit", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountNumber");

                    b.Property<decimal>("Amount");

                    b.Property<DateTime>("Date");

                    b.Property<string>("FolioNumber");

                    b.Property<bool>("Posted");

                    b.Property<string>("ReceiptNumber");

                    b.Property<string>("User");

                    b.HasKey("Id");

                    b.ToTable("Deposit");
                });

            modelBuilder.Entity("LodgerPms.Departments.Api.Model.FolioPattern", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("FolioPattern");
                });

            modelBuilder.Entity("LodgerPms.Departments.Api.Model.LogBook", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Date");

                    b.Property<string>("Department");

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.ToTable("LogBook");
                });

            modelBuilder.Entity("LodgerPms.Departments.Api.Model.MemberShip", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Arrival");

                    b.Property<string>("Departure");

                    b.Property<string>("Guest");

                    b.Property<string>("Level");

                    b.Property<string>("MemberNumber");

                    b.Property<string>("MemeberType");

                    b.HasKey("Id");

                    b.ToTable("MemberShip");
                });

            modelBuilder.Entity("LodgerPms.Departments.Api.Model.Package", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Allowance");

                    b.Property<string>("Alternate");

                    b.Property<int>("Attributes");

                    b.Property<decimal>("Average");

                    b.Property<string>("AverageCode");

                    b.Property<string>("CalculateRule");

                    b.Property<string>("CalculationRule");

                    b.Property<string>("Code");

                    b.Property<string>("CurrencyId");

                    b.Property<string>("Description");

                    b.Property<string>("ForesCastGroup");

                    b.Property<string>("Formula");

                    b.Property<string>("ItemInventory");

                    b.Property<string>("LossCode");

                    b.Property<bool>("PostNextDay");

                    b.Property<int>("PostingFrecuency");

                    b.Property<string>("ProfitCode");

                    b.Property<bool>("SellSeparate");

                    b.Property<string>("ShortDescription");

                    b.Property<bool>("TaxAverage");

                    b.Property<bool>("TaxAverageCode");

                    b.Property<string>("ValidFrom");

                    b.Property<string>("ValidTo");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Package");
                });

            modelBuilder.Entity("LodgerPms.Departments.Api.Model.PackageDetail", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Allowance");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("PackageId");

                    b.Property<decimal>("Price");

                    b.Property<string>("SeasonCode");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.HasIndex("PackageId");

                    b.ToTable("PackageDetail");
                });

            modelBuilder.Entity("LodgerPms.Departments.Api.Model.Valet", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action");

                    b.Property<string>("Description");

                    b.Property<string>("Location");

                    b.Property<string>("Reference");

                    b.Property<string>("TicketNumber");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Valet");
                });

            modelBuilder.Entity("LodgerPms.Domain.Common.Currency", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Symbol");

                    b.HasKey("Id");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("LodgerPms.Domain.Common.Money", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CurrencyId");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Money");
                });

            modelBuilder.Entity("LodgerPms.Departments.Api.Model.Department", b =>
                {
                    b.HasOne("LodgerPms.Departments.Api.Model.DepartmentGroup", "DepartmentGroup")
                        .WithMany()
                        .HasForeignKey("DepartmentGroupId");

                    b.HasOne("LodgerPms.Departments.Api.Model.Package", "Package")
                        .WithMany()
                        .HasForeignKey("PackageId");
                });

            modelBuilder.Entity("LodgerPms.Departments.Api.Model.Package", b =>
                {
                    b.HasOne("LodgerPms.Domain.Common.Money", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId");
                });

            modelBuilder.Entity("LodgerPms.Departments.Api.Model.PackageDetail", b =>
                {
                    b.HasOne("LodgerPms.Departments.Api.Model.Package", "Package")
                        .WithMany("Details")
                        .HasForeignKey("PackageId");
                });

            modelBuilder.Entity("LodgerPms.Domain.Common.Money", b =>
                {
                    b.HasOne("LodgerPms.Domain.Common.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId");
                });
        }
    }
}
