using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LodgerPms.DepartmentsDataLayer.Context;
using LodgerPms.Domain.Departments.Models;

namespace LodgerPms.DepartmentsDataLayer.Migrations
{
    [DbContext(typeof(DepartmentsContext))]
    [Migration("20170406180936_code1")]
    partial class code1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("lodgerpms.Domain.Common.Currency", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<bool>("IsValid");

                    b.Property<string>("Name");

                    b.Property<string>("Symbol");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("lodgerpms.Domain.Common.Money", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CurrencyId");

                    b.Property<bool>("Deleted");

                    b.Property<bool>("IsValid");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Money");
                });

            modelBuilder.Entity("LodgerPms.Domain.Departments.Models.Department", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<decimal>("Amount");

                    b.Property<bool>("ApplyTax");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("DepartmentGroupId");

                    b.Property<int>("DepartmentType");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("IsValid");

                    b.Property<string>("PackageId");

                    b.Property<decimal>("Percentage");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentGroupId");

                    b.HasIndex("PackageId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("LodgerPms.Domain.Departments.Models.DepartmentGroup", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description");

                    b.Property<bool>("IsValid");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("DepartmentGroups");
                });

            modelBuilder.Entity("LodgerPms.Domain.Departments.Models.Deposit", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountNumber");

                    b.Property<decimal>("Amount");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("Deleted");

                    b.Property<string>("FolioNumber");

                    b.Property<bool>("IsValid");

                    b.Property<bool>("Posted");

                    b.Property<string>("ReceiptNumber");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.Property<string>("User");

                    b.HasKey("Id");

                    b.ToTable("Deposits");
                });

            modelBuilder.Entity("LodgerPms.Domain.Departments.Models.FolioPattern", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description");

                    b.Property<bool>("IsValid");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("FolioPatterns");
                });

            modelBuilder.Entity("LodgerPms.Domain.Departments.Models.LogBook", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Date");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Department");

                    b.Property<string>("Description");

                    b.Property<bool>("IsValid");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("LogBooks");
                });

            modelBuilder.Entity("LodgerPms.Domain.Departments.Models.MemberShip", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Arrival");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Departure");

                    b.Property<string>("Guest");

                    b.Property<bool>("IsValid");

                    b.Property<string>("Level");

                    b.Property<string>("MemberNumber");

                    b.Property<string>("MemeberType");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("MemberShips");
                });

            modelBuilder.Entity("LodgerPms.Domain.Departments.Models.Package", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Allowance");

                    b.Property<string>("Alternate");

                    b.Property<int>("Attributes");

                    b.Property<decimal>("Average");

                    b.Property<string>("AverageCode");

                    b.Property<string>("CalcualtionRule");

                    b.Property<string>("CalculateRule");

                    b.Property<string>("Code");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CurrencyId");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description");

                    b.Property<string>("ForesCastGroup");

                    b.Property<string>("Formula");

                    b.Property<bool>("IsValid");

                    b.Property<string>("ItemInventory");

                    b.Property<string>("LossCode");

                    b.Property<bool>("PostNextDay");

                    b.Property<int>("PostingFrecuency");

                    b.Property<string>("ProfitCode");

                    b.Property<bool>("SellSeparate");

                    b.Property<string>("ShortDescription");

                    b.Property<bool>("TaxAverage");

                    b.Property<bool>("TaxAverageCode");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.Property<string>("ValidFrom");

                    b.Property<string>("ValidTo");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("LodgerPms.Domain.Departments.Models.PackageDetail", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Allowance");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("IsValid");

                    b.Property<string>("PackageId");

                    b.Property<decimal>("Price");

                    b.Property<string>("SeasonCode");

                    b.Property<DateTime>("StartDate");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("PackageId");

                    b.ToTable("PackageDetails");
                });

            modelBuilder.Entity("LodgerPms.Domain.Departments.Models.Valet", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description");

                    b.Property<bool>("IsValid");

                    b.Property<string>("Location");

                    b.Property<string>("Reference");

                    b.Property<string>("TicketNumber");

                    b.Property<string>("Type");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("Valets");
                });

            modelBuilder.Entity("lodgerpms.Domain.Common.Money", b =>
                {
                    b.HasOne("lodgerpms.Domain.Common.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId");
                });

            modelBuilder.Entity("LodgerPms.Domain.Departments.Models.Department", b =>
                {
                    b.HasOne("LodgerPms.Domain.Departments.Models.DepartmentGroup", "DepartmentGroup")
                        .WithMany()
                        .HasForeignKey("DepartmentGroupId");

                    b.HasOne("LodgerPms.Domain.Departments.Models.Package", "Package")
                        .WithMany()
                        .HasForeignKey("PackageId");
                });

            modelBuilder.Entity("LodgerPms.Domain.Departments.Models.Package", b =>
                {
                    b.HasOne("lodgerpms.Domain.Common.Money", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId");
                });

            modelBuilder.Entity("LodgerPms.Domain.Departments.Models.PackageDetail", b =>
                {
                    b.HasOne("LodgerPms.Domain.Departments.Models.Package", "Package")
                        .WithMany("Details")
                        .HasForeignKey("PackageId");
                });
        }
    }
}
