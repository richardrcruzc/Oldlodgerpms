using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LodgerPms.RoomsDataLayer;

namespace LodgerPms.RoomsDataLayer.Migrations
{
    [DbContext(typeof(RoomsContext))]
    [Migration("20170301051847_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("lodgerpms.Domain.Common.FullName", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("FullName");
                });

            modelBuilder.Entity("LodgerPms.Domain.Rooms.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("CompanyName");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("FullNameId");

                    b.Property<string>("Phone");

                    b.Property<string>("SalesPersonId");

                    b.HasKey("Id");

                    b.HasIndex("FullNameId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("LodgerPms.Domain.Rooms.Department", b =>
                {
                    b.HasOne("lodgerpms.Domain.Common.FullName", "FullName")
                        .WithMany()
                        .HasForeignKey("FullNameId");
                });
        }
    }
}
