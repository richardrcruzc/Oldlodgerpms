using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LodgerPms.Departments.Api.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DepartmentGroup",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deposit",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccountNumber = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    FolioNumber = table.Column<string>(nullable: true),
                    Posted = table.Column<bool>(nullable: false),
                    ReceiptNumber = table.Column<string>(nullable: true),
                    User = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FolioPattern",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FolioPattern", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogBook",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogBook", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberShip",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Arrival = table.Column<string>(nullable: true),
                    Departure = table.Column<string>(nullable: true),
                    Guest = table.Column<string>(nullable: true),
                    Level = table.Column<string>(nullable: true),
                    MemberNumber = table.Column<string>(nullable: true),
                    MemeberType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberShip", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Valet",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Action = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Reference = table.Column<string>(nullable: true),
                    TicketNumber = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Symbol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Money",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CurrencyId = table.Column<string>(nullable: true),
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
                name: "Package",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Allowance = table.Column<bool>(nullable: false),
                    Alternate = table.Column<string>(nullable: true),
                    Attributes = table.Column<int>(nullable: false),
                    Average = table.Column<decimal>(nullable: false),
                    AverageCode = table.Column<string>(nullable: true),
                    CalculateRule = table.Column<string>(nullable: true),
                    CalculationRule = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    CurrencyId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ForesCastGroup = table.Column<string>(nullable: true),
                    Formula = table.Column<string>(nullable: true),
                    ItemInventory = table.Column<string>(nullable: true),
                    LossCode = table.Column<string>(nullable: true),
                    PostNextDay = table.Column<bool>(nullable: false),
                    PostingFrecuency = table.Column<int>(nullable: false),
                    ProfitCode = table.Column<string>(nullable: true),
                    SellSeparate = table.Column<bool>(nullable: false),
                    ShortDescription = table.Column<string>(nullable: true),
                    TaxAverage = table.Column<bool>(nullable: false),
                    TaxAverageCode = table.Column<bool>(nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    ApplyTax = table.Column<bool>(nullable: false),
                    DepartmentGroupId = table.Column<string>(nullable: true),
                    DepartmentType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PackageId = table.Column<string>(nullable: true),
                    Percentage = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_DepartmentGroup_DepartmentGroupId",
                        column: x => x.DepartmentGroupId,
                        principalTable: "DepartmentGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Department_Package_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PackageDetail",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Allowance = table.Column<decimal>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    PackageId = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    SeasonCode = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Department_DepartmentGroupId",
                table: "Department",
                column: "DepartmentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_PackageId",
                table: "Department",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Package_CurrencyId",
                table: "Package",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageDetail_PackageId",
                table: "PackageDetail",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Money_CurrencyId",
                table: "Money",
                column: "CurrencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Deposit");

            migrationBuilder.DropTable(
                name: "FolioPattern");

            migrationBuilder.DropTable(
                name: "LogBook");

            migrationBuilder.DropTable(
                name: "MemberShip");

            migrationBuilder.DropTable(
                name: "PackageDetail");

            migrationBuilder.DropTable(
                name: "Valet");

            migrationBuilder.DropTable(
                name: "DepartmentGroup");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "Money");

            migrationBuilder.DropTable(
                name: "Currency");
        }
    }
}
