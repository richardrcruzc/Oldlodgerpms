using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LodgerPms.Persistence.FaceCover;
using LodgerPms.Domain.Agents;
using LodgerPms.Domain.Departments; 

namespace LodgerPms.Persistence.Migrations
{
    [DbContext(typeof(EFDomainDbContext))]
    partial class EFDomainDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LodgerPms.Domain.Agents.Rate", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Addition");

                    b.Property<bool>("AllInclusive");

                    b.Property<string>("Category");

                    b.Property<decimal>("ComissionCode");

                    b.Property<decimal>("CommissionPercentage");

                    b.Property<int>("Components");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("ExchangeType");

                    b.Property<string>("FolioText");

                    b.Property<bool>("IsComplimentary");

                    b.Property<string>("Market");

                    b.Property<int>("MaximumAdvanceBooking");

                    b.Property<int>("MaximumOcupancy");

                    b.Property<int>("MaximumStay");

                    b.Property<int>("MinimumAdvanceBooking");

                    b.Property<int>("MinimumOcupancy");

                    b.Property<int>("MinimumStay");

                    b.Property<int>("Multiplication");

                    b.Property<string>("PKGTrnCode");

                    b.Property<string>("RateCode");

                    b.Property<string>("Source");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("State");

                    b.Property<string>("TransactionCode");

                    b.Property<bool>("TransactionTax");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("Rate");
                });

            modelBuilder.Entity("LodgerPms.Domain.Bookings.Booking", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Abf");

                    b.Property<string>("AccountNumber");

                    b.Property<int>("AllotmentQty");

                    b.Property<DateTime>("ArriveDate");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime>("DepartureDate");

                    b.Property<decimal>("Dinner");

                    b.Property<decimal>("Discount");

                    b.Property<decimal>("ExtraBed");

                    b.Property<decimal>("ExtraBedService");

                    b.Property<decimal>("ExtraBedTax");

                    b.Property<bool>("IsComplimentary");

                    b.Property<decimal>("Lunch");

                    b.Property<string>("RateId");

                    b.Property<decimal>("RoomAmount");

                    b.Property<string>("RoomInfoBedTypeId");

                    b.Property<string>("RoomInfoId");

                    b.Property<string>("RoomInfoId1");

                    b.Property<string>("RoomInfoRoomLocationId");

                    b.Property<string>("RoomInfoRoomTypeId");

                    b.Property<string>("RoomStatusId");

                    b.Property<decimal>("Service");

                    b.Property<decimal>("Tax");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("RateId");

                    b.HasIndex("RoomStatusId")
                        .IsUnique();

                    b.HasIndex("RoomInfoId1", "RoomInfoRoomLocationId", "RoomInfoRoomTypeId", "RoomInfoBedTypeId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("LodgerPms.Domain.Bookings.GuestInfo", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BookingId");

                    b.Property<string>("Company");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<decimal>("CreditLimit");

                    b.Property<bool>("Deleted");

                    b.Property<bool>("InHouse");

                    b.Property<string>("PaymentId");

                    b.Property<string>("PersonId");

                    b.Property<string>("Position");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.HasIndex("PaymentId");

                    b.HasIndex("PersonId");

                    b.ToTable("GuestInfo");
                });

            modelBuilder.Entity("LodgerPms.Domain.Departments.Package", b =>
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

                    b.Property<string>("ItemInventory");

                    b.Property<string>("LossCode");

                    b.Property<bool>("PostNextDay");

                    b.Property<int>("PostingFrecuency");

                    b.Property<string>("ProfitCode");

                    b.Property<string>("RateId");

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

                    b.HasIndex("RateId");

                    b.ToTable("Package");
                });

            modelBuilder.Entity("LodgerPms.Domain.Departments.PackageDetail", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Allowance");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("PackageId");

                    b.Property<decimal>("Price");

                    b.Property<string>("SeasonCode");

                    b.Property<DateTime>("StartDate");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("PackageId");

                    b.ToTable("PackageDetail");
                });

            modelBuilder.Entity("LodgerPms.Domain.Rooms.BedType", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("BedType");
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

                    b.Property<string>("LocationId");

                    b.Property<int>("RoomQty");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.Property<string>("WebSite");

                    b.HasKey("Id");

                    b.HasIndex("DefaultBillingAddressId");

                    b.HasIndex("DefaultDeliveryAddressId");

                    b.HasIndex("LocationId");

                    b.ToTable("PropertyInfo");
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

                    b.Property<string>("RoomInfoBedTypeId");

                    b.Property<string>("RoomInfoId");

                    b.Property<string>("RoomInfoRoomLocationId");

                    b.Property<string>("RoomInfoRoomTypeId");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("RoomInfoId", "RoomInfoRoomLocationId", "RoomInfoRoomTypeId", "RoomInfoBedTypeId");

                    b.ToTable("RoomExposure");
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

                    b.Property<string>("RoomInfoListBedTypeId");

                    b.Property<string>("RoomInfoListId");

                    b.Property<string>("RoomInfoListRoomLocationId");

                    b.Property<string>("RoomInfoListRoomTypeId");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("RoomInfoListId", "RoomInfoListRoomLocationId", "RoomInfoListRoomTypeId", "RoomInfoListBedTypeId");

                    b.ToTable("RoomFacility");
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

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("RoomGroup");
                });

            modelBuilder.Entity("LodgerPms.Domain.Rooms.RoomInfo", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("RoomLocationId");

                    b.Property<string>("RoomTypeId");

                    b.Property<string>("BedTypeId");

                    b.Property<bool>("CanSmoke");

                    b.Property<bool>("CommonArea");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description");

                    b.Property<bool>("PseudoRoom");

                    b.Property<string>("RoomNumber");

                    b.Property<string>("RoomTypeId1");

                    b.Property<string>("RoomTypeRoomGroupId");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id", "RoomLocationId", "RoomTypeId", "BedTypeId");

                    b.HasIndex("BedTypeId");

                    b.HasIndex("RoomLocationId");

                    b.HasIndex("RoomTypeId1", "RoomTypeRoomGroupId");

                    b.ToTable("RoomInfo");
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

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("RoomLocation");
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

                    b.Property<int>("NumberOfPerson");

                    b.Property<string>("ReasonCode");

                    b.Property<int>("ReservationStatus");

                    b.Property<string>("RoomInfoBedTypeId");

                    b.Property<string>("RoomInfoId");

                    b.Property<string>("RoomInfoId1");

                    b.Property<string>("RoomInfoRoomLocationId");

                    b.Property<string>("RoomInfoRoomTypeId");

                    b.Property<DateTime>("StatusFrom");

                    b.Property<string>("StatusId");

                    b.Property<DateTime>("StatusTo");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.HasIndex("RoomInfoId1", "RoomInfoRoomLocationId", "RoomInfoRoomTypeId", "RoomInfoBedTypeId");

                    b.ToTable("RoomStatus");
                });

            modelBuilder.Entity("LodgerPms.Domain.Rooms.RoomType", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("RoomGroupId");

                    b.Property<string>("Code");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Description");

                    b.Property<int>("Maximun");

                    b.Property<string>("RateId");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id", "RoomGroupId");

                    b.HasIndex("RateId");

                    b.HasIndex("RoomGroupId");

                    b.ToTable("RoomType");
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

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("LodgerPms.Domain.Shared.ContactInformation", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ContactType");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("EmailAddressId");

                    b.Property<string>("PostalAddressId");

                    b.Property<string>("PrimaryTelephoneId");

                    b.Property<string>("SecondaryTelephoneId");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("EmailAddressId");

                    b.HasIndex("PostalAddressId");

                    b.HasIndex("PrimaryTelephoneId");

                    b.HasIndex("SecondaryTelephoneId");

                    b.ToTable("ContactInformation");
                });

            modelBuilder.Entity("LodgerPms.Domain.Shared.CreditCard", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("ExpiresId");

                    b.Property<string>("Number");

                    b.Property<string>("Owner");

                    b.Property<int>("Type");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("ExpiresId");

                    b.ToTable("CreditCard");
                });

            modelBuilder.Entity("LodgerPms.Domain.Shared.Currency", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Name");

                    b.Property<string>("Symbol");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("LodgerPms.Domain.Shared.EmailAddress", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<int>("EmailType");

                    b.Property<bool>("MailingList");

                    b.Property<string>("PropertyInfoId");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("PropertyInfoId");

                    b.ToTable("EmailAddress");
                });

            modelBuilder.Entity("LodgerPms.Domain.Shared.ExpiryDate", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<int>("Month");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime>("When");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.ToTable("ExpiryDate");
                });

            modelBuilder.Entity("LodgerPms.Domain.Shared.FullName", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("FullName");
                });

            modelBuilder.Entity("LodgerPms.Domain.Shared.Money", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CurrencyId");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.Property<decimal>("Value");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Money");
                });

            modelBuilder.Entity("LodgerPms.Domain.Shared.Person", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("DOB");

                    b.Property<bool>("Deleted");

                    b.Property<DateTime>("Expire");

                    b.Property<string>("FullNameId");

                    b.Property<int>("Gender");

                    b.Property<int>("IdentifcationType");

                    b.Property<string>("IdentifcationValue");

                    b.Property<DateTime>("Issue");

                    b.Property<string>("Nationality");

                    b.Property<int>("PersonType");

                    b.Property<string>("PropertyInfoId");

                    b.Property<int>("Title");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.Property<bool>("Vip");

                    b.HasKey("Id");

                    b.HasIndex("FullNameId");

                    b.HasIndex("PropertyInfoId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("LodgerPms.Domain.Shared.PostalAddress", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("CountryCode");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("PostalCode");

                    b.Property<string>("StateProvince");

                    b.Property<string>("StreetAddress");

                    b.Property<string>("StreetAddress2");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("PostalAddress");
                });

            modelBuilder.Entity("LodgerPms.Domain.Shared.Telephone", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Deleted");

                    b.Property<string>("Number");

                    b.Property<DateTime>("UpdateDate");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.ToTable("Telephone");
                });

            modelBuilder.Entity("LodgerPms.Domain.Bookings.Booking", b =>
                {
                    b.HasOne("LodgerPms.Domain.Agents.Rate", "Rate")
                        .WithMany()
                        .HasForeignKey("RateId");

                    b.HasOne("LodgerPms.Domain.Rooms.RoomStatus", "RoomStatus")
                        .WithOne("Booking")
                        .HasForeignKey("LodgerPms.Domain.Bookings.Booking", "RoomStatusId");

                    b.HasOne("LodgerPms.Domain.Rooms.RoomInfo", "RoomInfo")
                        .WithMany()
                        .HasForeignKey("RoomInfoId1", "RoomInfoRoomLocationId", "RoomInfoRoomTypeId", "RoomInfoBedTypeId");
                });

            modelBuilder.Entity("LodgerPms.Domain.Bookings.GuestInfo", b =>
                {
                    b.HasOne("LodgerPms.Domain.Bookings.Booking")
                        .WithMany("GuestInfoList")
                        .HasForeignKey("BookingId");

                    b.HasOne("LodgerPms.Domain.Shared.CreditCard", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId");

                    b.HasOne("LodgerPms.Domain.Shared.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("LodgerPms.Domain.Departments.Package", b =>
                {
                    b.HasOne("LodgerPms.Domain.Shared.Money", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId");

                    b.HasOne("LodgerPms.Domain.Agents.Rate")
                        .WithMany("Packages")
                        .HasForeignKey("RateId");
                });

            modelBuilder.Entity("LodgerPms.Domain.Departments.PackageDetail", b =>
                {
                    b.HasOne("LodgerPms.Domain.Departments.Package", "Package")
                        .WithMany("Details")
                        .HasForeignKey("PackageId");
                });

            modelBuilder.Entity("LodgerPms.Domain.Rooms.PropertyInfo", b =>
                {
                    b.HasOne("LodgerPms.Domain.Shared.ContactInformation", "DefaultBillingAddress")
                        .WithMany()
                        .HasForeignKey("DefaultBillingAddressId");

                    b.HasOne("LodgerPms.Domain.Shared.ContactInformation", "DefaultDeliveryAddress")
                        .WithMany()
                        .HasForeignKey("DefaultDeliveryAddressId");

                    b.HasOne("LodgerPms.Domain.Shared.ContactInformation", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("LodgerPms.Domain.Rooms.RoomExposure", b =>
                {
                    b.HasOne("LodgerPms.Domain.Rooms.RoomInfo")
                        .WithMany("RoomExposureList")
                        .HasForeignKey("RoomInfoId", "RoomInfoRoomLocationId", "RoomInfoRoomTypeId", "RoomInfoBedTypeId");
                });

            modelBuilder.Entity("LodgerPms.Domain.Rooms.RoomFacility", b =>
                {
                    b.HasOne("LodgerPms.Domain.Rooms.RoomInfo", "RoomInfoList")
                        .WithMany("RoomFacilityList")
                        .HasForeignKey("RoomInfoListId", "RoomInfoListRoomLocationId", "RoomInfoListRoomTypeId", "RoomInfoListBedTypeId");
                });

            modelBuilder.Entity("LodgerPms.Domain.Rooms.RoomInfo", b =>
                {
                    b.HasOne("LodgerPms.Domain.Rooms.BedType", "BedType")
                        .WithMany("RoomInfoList")
                        .HasForeignKey("BedTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LodgerPms.Domain.Rooms.RoomLocation", "RoomLocation")
                        .WithMany("RoomInfoList")
                        .HasForeignKey("RoomLocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LodgerPms.Domain.Rooms.RoomType", "RoomType")
                        .WithMany("RoomInfoList")
                        .HasForeignKey("RoomTypeId1", "RoomTypeRoomGroupId");
                });

            modelBuilder.Entity("LodgerPms.Domain.Rooms.RoomStatus", b =>
                {
                    b.HasOne("LodgerPms.Domain.Rooms.Status", "Status")
                        .WithMany("RoomStatusList")
                        .HasForeignKey("StatusId");

                    b.HasOne("LodgerPms.Domain.Rooms.RoomInfo", "RoomInfo")
                        .WithMany("RoomStatusList")
                        .HasForeignKey("RoomInfoId1", "RoomInfoRoomLocationId", "RoomInfoRoomTypeId", "RoomInfoBedTypeId");
                });

            modelBuilder.Entity("LodgerPms.Domain.Rooms.RoomType", b =>
                {
                    b.HasOne("LodgerPms.Domain.Agents.Rate")
                        .WithMany("RoomTypes")
                        .HasForeignKey("RateId");

                    b.HasOne("LodgerPms.Domain.Rooms.RoomGroup", "Group")
                        .WithMany("RoomTypeList")
                        .HasForeignKey("RoomGroupId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LodgerPms.Domain.Shared.ContactInformation", b =>
                {
                    b.HasOne("LodgerPms.Domain.Shared.EmailAddress", "EmailAddress")
                        .WithMany()
                        .HasForeignKey("EmailAddressId");

                    b.HasOne("LodgerPms.Domain.Shared.PostalAddress", "PostalAddress")
                        .WithMany()
                        .HasForeignKey("PostalAddressId");

                    b.HasOne("LodgerPms.Domain.Shared.Telephone", "PrimaryTelephone")
                        .WithMany()
                        .HasForeignKey("PrimaryTelephoneId");

                    b.HasOne("LodgerPms.Domain.Shared.Telephone", "SecondaryTelephone")
                        .WithMany()
                        .HasForeignKey("SecondaryTelephoneId");
                });

            modelBuilder.Entity("LodgerPms.Domain.Shared.CreditCard", b =>
                {
                    b.HasOne("LodgerPms.Domain.Shared.ExpiryDate", "Expires")
                        .WithMany()
                        .HasForeignKey("ExpiresId");
                });

            modelBuilder.Entity("LodgerPms.Domain.Shared.EmailAddress", b =>
                {
                    b.HasOne("LodgerPms.Domain.Rooms.PropertyInfo")
                        .WithMany("Emails")
                        .HasForeignKey("PropertyInfoId");
                });

            modelBuilder.Entity("LodgerPms.Domain.Shared.Money", b =>
                {
                    b.HasOne("LodgerPms.Domain.Shared.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId");
                });

            modelBuilder.Entity("LodgerPms.Domain.Shared.Person", b =>
                {
                    b.HasOne("LodgerPms.Domain.Shared.FullName", "FullName")
                        .WithMany()
                        .HasForeignKey("FullNameId");

                    b.HasOne("LodgerPms.Domain.Rooms.PropertyInfo")
                        .WithMany("Contacts")
                        .HasForeignKey("PropertyInfoId");
                });
        }
    }
}
