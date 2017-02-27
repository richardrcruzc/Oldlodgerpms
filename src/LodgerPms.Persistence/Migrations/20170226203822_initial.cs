using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LodgerPms.Persistence.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rate",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Addition = table.Column<int>(nullable: false),
                    AllInclusive = table.Column<bool>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    ComissionCode = table.Column<decimal>(nullable: false),
                    CommissionPercentage = table.Column<decimal>(nullable: false),
                    Components = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: false),
                    ExchangeType = table.Column<string>(nullable: true),
                    FolioText = table.Column<string>(nullable: true),
                    IsComplimentary = table.Column<bool>(nullable: false),
                    Market = table.Column<string>(nullable: true),
                    MaximumAdvanceBooking = table.Column<int>(nullable: false),
                    MaximumOcupancy = table.Column<int>(nullable: false),
                    MaximumStay = table.Column<int>(nullable: false),
                    MinimumAdvanceBooking = table.Column<int>(nullable: false),
                    MinimumOcupancy = table.Column<int>(nullable: false),
                    MinimumStay = table.Column<int>(nullable: false),
                    Multiplication = table.Column<int>(nullable: false),
                    PKGTrnCode = table.Column<string>(nullable: true),
                    RateCode = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    TransactionCode = table.Column<string>(nullable: true),
                    TransactionTax = table.Column<bool>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BedType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BedType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomGroup",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomLocation",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomLocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpiryDate",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Month = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    When = table.Column<DateTime>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpiryDate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FullName",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullName", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostalAddress",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    PostalCode = table.Column<string>(nullable: true),
                    StateProvince = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    StreetAddress2 = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostalAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Telephone",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telephone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    RoomGroupId = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Maximun = table.Column<int>(nullable: false),
                    RateId = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomType", x => new { x.Id, x.RoomGroupId });
                    table.ForeignKey(
                        name: "FK_RoomType_Rate_RateId",
                        column: x => x.RateId,
                        principalTable: "Rate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomType_RoomGroup_RoomGroupId",
                        column: x => x.RoomGroupId,
                        principalTable: "RoomGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Money",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CurrencyId = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Money", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Money_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CreditCard",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    ExpiresId = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Owner = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCard_ExpiryDate_ExpiresId",
                        column: x => x.ExpiresId,
                        principalTable: "ExpiryDate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomInfo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    RoomLocationId = table.Column<string>(nullable: false),
                    RoomTypeId = table.Column<string>(nullable: false),
                    BedTypeId = table.Column<string>(nullable: false),
                    CanSmoke = table.Column<bool>(nullable: false),
                    CommonArea = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PseudoRoom = table.Column<bool>(nullable: false),
                    RoomNumber = table.Column<string>(nullable: true),
                    RoomTypeId1 = table.Column<string>(nullable: true),
                    RoomTypeRoomGroupId = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomInfo", x => new { x.Id, x.RoomLocationId, x.RoomTypeId, x.BedTypeId });
                    table.ForeignKey(
                        name: "FK_RoomInfo_BedType_BedTypeId",
                        column: x => x.BedTypeId,
                        principalTable: "BedType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomInfo_RoomLocation_RoomLocationId",
                        column: x => x.RoomLocationId,
                        principalTable: "RoomLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomInfo_RoomType_RoomTypeId1_RoomTypeRoomGroupId",
                        columns: x => new { x.RoomTypeId1, x.RoomTypeRoomGroupId },
                        principalTable: "RoomType",
                        principalColumns: new[] { "Id", "RoomGroupId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Allowance = table.Column<bool>(nullable: false),
                    Alternate = table.Column<string>(nullable: true),
                    Attributes = table.Column<int>(nullable: false),
                    Average = table.Column<decimal>(nullable: false),
                    AverageCode = table.Column<string>(nullable: true),
                    CalcualtionRule = table.Column<string>(nullable: true),
                    CalculateRule = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CurrencyId = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ForesCastGroup = table.Column<string>(nullable: true),
                    Formula = table.Column<string>(nullable: true),
                    ItemInventory = table.Column<string>(nullable: true),
                    LossCode = table.Column<string>(nullable: true),
                    PostNextDay = table.Column<bool>(nullable: false),
                    PostingFrecuency = table.Column<int>(nullable: false),
                    ProfitCode = table.Column<string>(nullable: true),
                    RateId = table.Column<string>(nullable: true),
                    SellSeparate = table.Column<bool>(nullable: false),
                    ShortDescription = table.Column<string>(nullable: true),
                    TaxAverage = table.Column<bool>(nullable: false),
                    TaxAverageCode = table.Column<bool>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    ValidFrom = table.Column<string>(nullable: true),
                    ValidTo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Package_Money_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Money",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Package_Rate_RateId",
                        column: x => x.RateId,
                        principalTable: "Rate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomExposure",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    RoomInfoBedTypeId = table.Column<string>(nullable: true),
                    RoomInfoId = table.Column<string>(nullable: true),
                    RoomInfoRoomLocationId = table.Column<string>(nullable: true),
                    RoomInfoRoomTypeId = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomExposure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomExposure_RoomInfo_RoomInfoId_RoomInfoRoomLocationId_RoomInfoRoomTypeId_RoomInfoBedTypeId",
                        columns: x => new { x.RoomInfoId, x.RoomInfoRoomLocationId, x.RoomInfoRoomTypeId, x.RoomInfoBedTypeId },
                        principalTable: "RoomInfo",
                        principalColumns: new[] { "Id", "RoomLocationId", "RoomTypeId", "BedTypeId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomFacility",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    RoomInfoListBedTypeId = table.Column<string>(nullable: true),
                    RoomInfoListId = table.Column<string>(nullable: true),
                    RoomInfoListRoomLocationId = table.Column<string>(nullable: true),
                    RoomInfoListRoomTypeId = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomFacility", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomFacility_RoomInfo_RoomInfoListId_RoomInfoListRoomLocationId_RoomInfoListRoomTypeId_RoomInfoListBedTypeId",
                        columns: x => new { x.RoomInfoListId, x.RoomInfoListRoomLocationId, x.RoomInfoListRoomTypeId, x.RoomInfoListBedTypeId },
                        principalTable: "RoomInfo",
                        principalColumns: new[] { "Id", "RoomLocationId", "RoomTypeId", "BedTypeId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomStatus",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AssignedDate = table.Column<DateTime>(nullable: false),
                    AssignedTo = table.Column<string>(nullable: true),
                    Assignedby = table.Column<string>(nullable: true),
                    BookingId = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    GuestServiceStatus = table.Column<int>(nullable: false),
                    HKNumberOfPerson = table.Column<int>(nullable: false),
                    HKStatus = table.Column<int>(nullable: false),
                    NumberOfPerson = table.Column<int>(nullable: false),
                    ReasonCode = table.Column<string>(nullable: true),
                    ReservationStatus = table.Column<int>(nullable: false),
                    RoomInfoBedTypeId = table.Column<string>(nullable: true),
                    RoomInfoId = table.Column<string>(nullable: true),
                    RoomInfoId1 = table.Column<string>(nullable: true),
                    RoomInfoRoomLocationId = table.Column<string>(nullable: true),
                    RoomInfoRoomTypeId = table.Column<string>(nullable: true),
                    StatusFrom = table.Column<DateTime>(nullable: false),
                    StatusId = table.Column<string>(nullable: true),
                    StatusTo = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomStatus_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomStatus_RoomInfo_RoomInfoId1_RoomInfoRoomLocationId_RoomInfoRoomTypeId_RoomInfoBedTypeId",
                        columns: x => new { x.RoomInfoId1, x.RoomInfoRoomLocationId, x.RoomInfoRoomTypeId, x.RoomInfoBedTypeId },
                        principalTable: "RoomInfo",
                        principalColumns: new[] { "Id", "RoomLocationId", "RoomTypeId", "BedTypeId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PackageDetail",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Allowance = table.Column<decimal>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    PackageId = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    SeasonCode = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageDetail_Package_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Abf = table.Column<decimal>(nullable: false),
                    AccountNumber = table.Column<string>(nullable: true),
                    AllotmentQty = table.Column<int>(nullable: false),
                    ArriveDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    DepartureDate = table.Column<DateTime>(nullable: false),
                    Dinner = table.Column<decimal>(nullable: false),
                    Discount = table.Column<decimal>(nullable: false),
                    ExtraBed = table.Column<decimal>(nullable: false),
                    ExtraBedService = table.Column<decimal>(nullable: false),
                    ExtraBedTax = table.Column<decimal>(nullable: false),
                    IsComplimentary = table.Column<bool>(nullable: false),
                    Lunch = table.Column<decimal>(nullable: false),
                    RateId = table.Column<string>(nullable: true),
                    RoomAmount = table.Column<decimal>(nullable: false),
                    RoomInfoBedTypeId = table.Column<string>(nullable: true),
                    RoomInfoId = table.Column<string>(nullable: true),
                    RoomInfoId1 = table.Column<string>(nullable: true),
                    RoomInfoRoomLocationId = table.Column<string>(nullable: true),
                    RoomInfoRoomTypeId = table.Column<string>(nullable: true),
                    RoomStatusId = table.Column<string>(nullable: true),
                    Service = table.Column<decimal>(nullable: false),
                    Tax = table.Column<decimal>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Rate_RateId",
                        column: x => x.RateId,
                        principalTable: "Rate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_RoomStatus_RoomStatusId",
                        column: x => x.RoomStatusId,
                        principalTable: "RoomStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_RoomInfo_RoomInfoId1_RoomInfoRoomLocationId_RoomInfoRoomTypeId_RoomInfoBedTypeId",
                        columns: x => new { x.RoomInfoId1, x.RoomInfoRoomLocationId, x.RoomInfoRoomTypeId, x.RoomInfoBedTypeId },
                        principalTable: "RoomInfo",
                        principalColumns: new[] { "Id", "RoomLocationId", "RoomTypeId", "BedTypeId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GuestInfo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    BookingId = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CreditLimit = table.Column<decimal>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    InHouse = table.Column<bool>(nullable: false),
                    PaymentId = table.Column<string>(nullable: true),
                    PersonId = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuestInfo_Booking_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Booking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GuestInfo_CreditCard_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "CreditCard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmailAddress",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    EmailType = table.Column<int>(nullable: false),
                    MailingList = table.Column<bool>(nullable: false),
                    PropertyInfoId = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactInformation",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ContactType = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    EmailAddressId = table.Column<string>(nullable: true),
                    PostalAddressId = table.Column<string>(nullable: true),
                    PrimaryTelephoneId = table.Column<string>(nullable: true),
                    SecondaryTelephoneId = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactInformation_EmailAddress_EmailAddressId",
                        column: x => x.EmailAddressId,
                        principalTable: "EmailAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContactInformation_PostalAddress_PostalAddressId",
                        column: x => x.PostalAddressId,
                        principalTable: "PostalAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContactInformation_Telephone_PrimaryTelephoneId",
                        column: x => x.PrimaryTelephoneId,
                        principalTable: "Telephone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContactInformation_Telephone_SecondaryTelephoneId",
                        column: x => x.SecondaryTelephoneId,
                        principalTable: "Telephone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropertyInfo",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DefaultBillingAddressId = table.Column<string>(nullable: true),
                    DefaultDeliveryAddressId = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    LocationId = table.Column<string>(nullable: true),
                    RoomQty = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyInfo_ContactInformation_DefaultBillingAddressId",
                        column: x => x.DefaultBillingAddressId,
                        principalTable: "ContactInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropertyInfo_ContactInformation_DefaultDeliveryAddressId",
                        column: x => x.DefaultDeliveryAddressId,
                        principalTable: "ContactInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropertyInfo_ContactInformation_LocationId",
                        column: x => x.LocationId,
                        principalTable: "ContactInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Expire = table.Column<DateTime>(nullable: false),
                    FullNameId = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    IdentifcationType = table.Column<int>(nullable: false),
                    IdentifcationValue = table.Column<string>(nullable: true),
                    Issue = table.Column<DateTime>(nullable: false),
                    Nationality = table.Column<string>(nullable: true),
                    PersonType = table.Column<int>(nullable: false),
                    PropertyInfoId = table.Column<string>(nullable: true),
                    Title = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Vip = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_FullName_FullNameId",
                        column: x => x.FullNameId,
                        principalTable: "FullName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_PropertyInfo_PropertyInfoId",
                        column: x => x.PropertyInfoId,
                        principalTable: "PropertyInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_RateId",
                table: "Booking",
                column: "RateId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_RoomStatusId",
                table: "Booking",
                column: "RoomStatusId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Booking_RoomInfoId1_RoomInfoRoomLocationId_RoomInfoRoomTypeId_RoomInfoBedTypeId",
                table: "Booking",
                columns: new[] { "RoomInfoId1", "RoomInfoRoomLocationId", "RoomInfoRoomTypeId", "RoomInfoBedTypeId" });

            migrationBuilder.CreateIndex(
                name: "IX_GuestInfo_BookingId",
                table: "GuestInfo",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestInfo_PaymentId",
                table: "GuestInfo",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestInfo_PersonId",
                table: "GuestInfo",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Package_CurrencyId",
                table: "Package",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Package_RateId",
                table: "Package",
                column: "RateId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageDetail_PackageId",
                table: "PackageDetail",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyInfo_DefaultBillingAddressId",
                table: "PropertyInfo",
                column: "DefaultBillingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyInfo_DefaultDeliveryAddressId",
                table: "PropertyInfo",
                column: "DefaultDeliveryAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyInfo_LocationId",
                table: "PropertyInfo",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomExposure_RoomInfoId_RoomInfoRoomLocationId_RoomInfoRoomTypeId_RoomInfoBedTypeId",
                table: "RoomExposure",
                columns: new[] { "RoomInfoId", "RoomInfoRoomLocationId", "RoomInfoRoomTypeId", "RoomInfoBedTypeId" });

            migrationBuilder.CreateIndex(
                name: "IX_RoomFacility_RoomInfoListId_RoomInfoListRoomLocationId_RoomInfoListRoomTypeId_RoomInfoListBedTypeId",
                table: "RoomFacility",
                columns: new[] { "RoomInfoListId", "RoomInfoListRoomLocationId", "RoomInfoListRoomTypeId", "RoomInfoListBedTypeId" });

            migrationBuilder.CreateIndex(
                name: "IX_RoomInfo_BedTypeId",
                table: "RoomInfo",
                column: "BedTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomInfo_RoomLocationId",
                table: "RoomInfo",
                column: "RoomLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomInfo_RoomTypeId1_RoomTypeRoomGroupId",
                table: "RoomInfo",
                columns: new[] { "RoomTypeId1", "RoomTypeRoomGroupId" });

            migrationBuilder.CreateIndex(
                name: "IX_RoomStatus_StatusId",
                table: "RoomStatus",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomStatus_RoomInfoId1_RoomInfoRoomLocationId_RoomInfoRoomTypeId_RoomInfoBedTypeId",
                table: "RoomStatus",
                columns: new[] { "RoomInfoId1", "RoomInfoRoomLocationId", "RoomInfoRoomTypeId", "RoomInfoBedTypeId" });

            migrationBuilder.CreateIndex(
                name: "IX_RoomType_RateId",
                table: "RoomType",
                column: "RateId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomType_RoomGroupId",
                table: "RoomType",
                column: "RoomGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInformation_EmailAddressId",
                table: "ContactInformation",
                column: "EmailAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInformation_PostalAddressId",
                table: "ContactInformation",
                column: "PostalAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInformation_PrimaryTelephoneId",
                table: "ContactInformation",
                column: "PrimaryTelephoneId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInformation_SecondaryTelephoneId",
                table: "ContactInformation",
                column: "SecondaryTelephoneId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCard_ExpiresId",
                table: "CreditCard",
                column: "ExpiresId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailAddress_PropertyInfoId",
                table: "EmailAddress",
                column: "PropertyInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Money_CurrencyId",
                table: "Money",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_FullNameId",
                table: "Person",
                column: "FullNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_PropertyInfoId",
                table: "Person",
                column: "PropertyInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_GuestInfo_Person_PersonId",
                table: "GuestInfo",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmailAddress_PropertyInfo_PropertyInfoId",
                table: "EmailAddress",
                column: "PropertyInfoId",
                principalTable: "PropertyInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyInfo_ContactInformation_DefaultBillingAddressId",
                table: "PropertyInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyInfo_ContactInformation_DefaultDeliveryAddressId",
                table: "PropertyInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyInfo_ContactInformation_LocationId",
                table: "PropertyInfo");

            migrationBuilder.DropTable(
                name: "GuestInfo");

            migrationBuilder.DropTable(
                name: "PackageDetail");

            migrationBuilder.DropTable(
                name: "RoomExposure");

            migrationBuilder.DropTable(
                name: "RoomFacility");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "CreditCard");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "RoomStatus");

            migrationBuilder.DropTable(
                name: "ExpiryDate");

            migrationBuilder.DropTable(
                name: "FullName");

            migrationBuilder.DropTable(
                name: "Money");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "RoomInfo");

            migrationBuilder.DropTable(
                name: "Currency");

            migrationBuilder.DropTable(
                name: "BedType");

            migrationBuilder.DropTable(
                name: "RoomLocation");

            migrationBuilder.DropTable(
                name: "RoomType");

            migrationBuilder.DropTable(
                name: "Rate");

            migrationBuilder.DropTable(
                name: "RoomGroup");

            migrationBuilder.DropTable(
                name: "ContactInformation");

            migrationBuilder.DropTable(
                name: "EmailAddress");

            migrationBuilder.DropTable(
                name: "PostalAddress");

            migrationBuilder.DropTable(
                name: "Telephone");

            migrationBuilder.DropTable(
                name: "PropertyInfo");
        }
    }
}
