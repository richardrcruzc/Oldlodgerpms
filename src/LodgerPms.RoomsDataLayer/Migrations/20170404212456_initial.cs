using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LodgerPms.RoomsDataLayer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BedTypes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsValid = table.Column<bool>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BedTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyInfos",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DefaultBillingAddressId = table.Column<string>(nullable: true),
                    DefaultDeliveryAddressId = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsValid = table.Column<bool>(nullable: false),
                    LocationId = table.Column<string>(nullable: true),
                    RoomQty = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomGroups",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsValid = table.Column<bool>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomLocations",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsValid = table.Column<bool>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statues",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsValid = table.Column<bool>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsValid = table.Column<bool>(nullable: false),
                    Maximun = table.Column<int>(nullable: false),
                    RoomGroupId = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomTypes_RoomGroups_RoomGroupId",
                        column: x => x.RoomGroupId,
                        principalTable: "RoomGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomInfos",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    BedTypeId = table.Column<string>(nullable: true),
                    CanSmoke = table.Column<bool>(nullable: false),
                    CommonArea = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsValid = table.Column<bool>(nullable: false),
                    PseudoRoom = table.Column<bool>(nullable: false),
                    RoomLocationId = table.Column<string>(nullable: true),
                    RoomNumber = table.Column<string>(nullable: true),
                    RoomTypeId = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomInfos_BedTypes_BedTypeId",
                        column: x => x.BedTypeId,
                        principalTable: "BedTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomInfos_RoomLocations_RoomLocationId",
                        column: x => x.RoomLocationId,
                        principalTable: "RoomLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomInfos_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomExposures",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsValid = table.Column<bool>(nullable: false),
                    RoomInfoId = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomExposures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomExposures_RoomInfos_RoomInfoId",
                        column: x => x.RoomInfoId,
                        principalTable: "RoomInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomFacilities",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsValid = table.Column<bool>(nullable: false),
                    RoomInfoListId = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomFacilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomFacilities_RoomInfos_RoomInfoListId",
                        column: x => x.RoomInfoListId,
                        principalTable: "RoomInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomStatues",
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
                    IsValid = table.Column<bool>(nullable: false),
                    NumberOfPerson = table.Column<int>(nullable: false),
                    ReasonCode = table.Column<string>(nullable: true),
                    ReservationStatus = table.Column<int>(nullable: false),
                    RoomInfoId = table.Column<string>(nullable: true),
                    StatusFrom = table.Column<DateTime>(nullable: false),
                    StatusId = table.Column<string>(nullable: true),
                    StatusTo = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomStatues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomStatues_RoomInfos_RoomInfoId",
                        column: x => x.RoomInfoId,
                        principalTable: "RoomInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomStatues_Statues_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomExposures_RoomInfoId",
                table: "RoomExposures",
                column: "RoomInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomFacilities_RoomInfoListId",
                table: "RoomFacilities",
                column: "RoomInfoListId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomInfos_BedTypeId",
                table: "RoomInfos",
                column: "BedTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomInfos_RoomLocationId",
                table: "RoomInfos",
                column: "RoomLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomInfos_RoomTypeId",
                table: "RoomInfos",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomStatues_RoomInfoId",
                table: "RoomStatues",
                column: "RoomInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomStatues_StatusId",
                table: "RoomStatues",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomTypes_RoomGroupId",
                table: "RoomTypes",
                column: "RoomGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PropertyInfos");

            migrationBuilder.DropTable(
                name: "RoomExposures");

            migrationBuilder.DropTable(
                name: "RoomFacilities");

            migrationBuilder.DropTable(
                name: "RoomStatues");

            migrationBuilder.DropTable(
                name: "RoomInfos");

            migrationBuilder.DropTable(
                name: "Statues");

            migrationBuilder.DropTable(
                name: "BedTypes");

            migrationBuilder.DropTable(
                name: "RoomLocations");

            migrationBuilder.DropTable(
                name: "RoomTypes");

            migrationBuilder.DropTable(
                name: "RoomGroups");
        }
    }
}
