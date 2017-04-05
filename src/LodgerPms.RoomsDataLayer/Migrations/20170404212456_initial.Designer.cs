using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LodgerPms.RoomsDataLayer.Context;
using lodgerpms.Domain.Common;

namespace LodgerPms.RoomsDataLayer.Migrations
{
    [DbContext(typeof(RoomsContext))]
    [Migration("20170404212456_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LodgerPms.Domain.Rooms.BedType", b =>
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

                    b.ToTable("BedTypes");
                });

            modelBuilder.Entity("LodgerPms.Domain.Rooms.PropertyInfo", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("DefaultBillingAddressId");

                    b.Property<string>("DefaultDeliveryAddressId");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description");

                    b.Property<bool>("IsValid");

                    b.Property<string>("LocationId");

                    b.Property<int>("RoomQty");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.Property<string>("WebSite");

                    b.HasKey("Id");

                    b.ToTable("PropertyInfos");
                });

            modelBuilder.Entity("LodgerPms.Domain.Rooms.RoomExposure", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description");

                    b.Property<bool>("IsValid");

                    b.Property<string>("RoomInfoId");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("RoomInfoId");

                    b.ToTable("RoomExposures");
                });

            modelBuilder.Entity("LodgerPms.Domain.Rooms.RoomFacility", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description");

                    b.Property<bool>("IsValid");

                    b.Property<string>("RoomInfoListId");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("RoomInfoListId");

                    b.ToTable("RoomFacilities");
                });

            modelBuilder.Entity("LodgerPms.Domain.Rooms.RoomGroup", b =>
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

                    b.ToTable("RoomGroups");
                });

            modelBuilder.Entity("LodgerPms.Domain.Rooms.RoomInfo", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BedTypeId");

                    b.Property<bool>("CanSmoke");

                    b.Property<bool>("CommonArea");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description");

                    b.Property<bool>("IsValid");

                    b.Property<bool>("PseudoRoom");

                    b.Property<string>("RoomLocationId");

                    b.Property<string>("RoomNumber");

                    b.Property<string>("RoomTypeId");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("BedTypeId");

                    b.HasIndex("RoomLocationId");

                    b.HasIndex("RoomTypeId");

                    b.ToTable("RoomInfos");
                });

            modelBuilder.Entity("LodgerPms.Domain.Rooms.RoomLocation", b =>
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

                    b.ToTable("RoomLocations");
                });

            modelBuilder.Entity("LodgerPms.Domain.Rooms.RoomStatus", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AssignedDate");

                    b.Property<string>("AssignedTo");

                    b.Property<string>("Assignedby");

                    b.Property<string>("BookingId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description");

                    b.Property<int>("GuestServiceStatus");

                    b.Property<int>("HKNumberOfPerson");

                    b.Property<int>("HKStatus");

                    b.Property<bool>("IsValid");

                    b.Property<int>("NumberOfPerson");

                    b.Property<string>("ReasonCode");

                    b.Property<int>("ReservationStatus");

                    b.Property<string>("RoomInfoId");

                    b.Property<DateTime>("StatusFrom");

                    b.Property<string>("StatusId");

                    b.Property<DateTime>("StatusTo");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("RoomInfoId");

                    b.HasIndex("StatusId");

                    b.ToTable("RoomStatues");
                });

            modelBuilder.Entity("LodgerPms.Domain.Rooms.RoomType", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description");

                    b.Property<bool>("IsValid");

                    b.Property<int>("Maximun");

                    b.Property<string>("RoomGroupId");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("RoomGroupId");

                    b.ToTable("RoomTypes");
                });

            modelBuilder.Entity("LodgerPms.Domain.Rooms.Status", b =>
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

                    b.ToTable("Statues");
                });

            modelBuilder.Entity("LodgerPms.Domain.Rooms.RoomExposure", b =>
                {
                    b.HasOne("LodgerPms.Domain.Rooms.RoomInfo")
                        .WithMany("RoomExposureList")
                        .HasForeignKey("RoomInfoId");
                });

            modelBuilder.Entity("LodgerPms.Domain.Rooms.RoomFacility", b =>
                {
                    b.HasOne("LodgerPms.Domain.Rooms.RoomInfo", "RoomInfoList")
                        .WithMany("RoomFacilityList")
                        .HasForeignKey("RoomInfoListId");
                });

            modelBuilder.Entity("LodgerPms.Domain.Rooms.RoomInfo", b =>
                {
                    b.HasOne("LodgerPms.Domain.Rooms.BedType", "BedType")
                        .WithMany("RoomInfoList")
                        .HasForeignKey("BedTypeId");

                    b.HasOne("LodgerPms.Domain.Rooms.RoomLocation", "RoomLocation")
                        .WithMany("RoomInfoList")
                        .HasForeignKey("RoomLocationId");

                    b.HasOne("LodgerPms.Domain.Rooms.RoomType", "RoomType")
                        .WithMany("RoomInfoList")
                        .HasForeignKey("RoomTypeId");
                });

            modelBuilder.Entity("LodgerPms.Domain.Rooms.RoomStatus", b =>
                {
                    b.HasOne("LodgerPms.Domain.Rooms.RoomInfo", "RoomInfo")
                        .WithMany("RoomStatusList")
                        .HasForeignKey("RoomInfoId");

                    b.HasOne("LodgerPms.Domain.Rooms.Status", "Status")
                        .WithMany("RoomStatusList")
                        .HasForeignKey("StatusId");
                });

            modelBuilder.Entity("LodgerPms.Domain.Rooms.RoomType", b =>
                {
                    b.HasOne("LodgerPms.Domain.Rooms.RoomGroup", "Group")
                        .WithMany("RoomTypeList")
                        .HasForeignKey("RoomGroupId");
                });
        }
    }
}
