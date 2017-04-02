using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LodgerPms.DepartmentsDataLayer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    IsValid = table.Column<bool>(nullable: false),
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
                name: "Deposits",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccountNumber = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    FolioNumber = table.Column<string>(nullable: true),
                    IsValid = table.Column<bool>(nullable: false),
                    Posted = table.Column<bool>(nullable: false),
                    ReceiptNumber = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    User = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deposits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FolioPatterns",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
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
                    table.PrimaryKey("PK_FolioPatterns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogBooks",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    Department = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsValid = table.Column<bool>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogBooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberShips",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Arrival = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Departure = table.Column<string>(nullable: true),
                    Guest = table.Column<string>(nullable: true),
                    IsValid = table.Column<bool>(nullable: false),
                    Level = table.Column<string>(nullable: true),
                    MemberNumber = table.Column<string>(nullable: true),
                    MemeberType = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberShips", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Valets",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Action = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsValid = table.Column<bool>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Reference = table.Column<string>(nullable: true),
                    TicketNumber = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valets", x => x.Id);
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
                    IsValid = table.Column<bool>(nullable: false),
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
                name: "DepartmentGroups",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    CurrencyId = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsValid = table.Column<bool>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentGroups_Money_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Money",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
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
                    IsValid = table.Column<bool>(nullable: false),
                    ItemInventory = table.Column<string>(nullable: true),
                    LossCode = table.Column<string>(nullable: true),
                    PostNextDay = table.Column<bool>(nullable: false),
                    PostingFrecuency = table.Column<int>(nullable: false),
                    ProfitCode = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_Packages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Packages_Money_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Money",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    ApplyTax = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    DepartmentGroupId = table.Column<string>(nullable: true),
                    DepartmentType = table.Column<int>(nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsValid = table.Column<bool>(nullable: false),
                    PackageId = table.Column<string>(nullable: true),
                    Percentage = table.Column<decimal>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_DepartmentGroups_DepartmentGroupId",
                        column: x => x.DepartmentGroupId,
                        principalTable: "DepartmentGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Departments_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PackageDetails",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Allowance = table.Column<decimal>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    IsValid = table.Column<bool>(nullable: false),
                    PackageId = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    SeasonCode = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageDetails_Packages_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Money_CurrencyId",
                table: "Money",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DepartmentGroupId",
                table: "Departments",
                column: "DepartmentGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_PackageId",
                table: "Departments",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentGroups_CurrencyId",
                table: "DepartmentGroups",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_CurrencyId",
                table: "Packages",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageDetails_PackageId",
                table: "PackageDetails",
                column: "PackageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Deposits");

            migrationBuilder.DropTable(
                name: "FolioPatterns");

            migrationBuilder.DropTable(
                name: "LogBooks");

            migrationBuilder.DropTable(
                name: "MemberShips");

            migrationBuilder.DropTable(
                name: "PackageDetails");

            migrationBuilder.DropTable(
                name: "Valets");

            migrationBuilder.DropTable(
                name: "DepartmentGroups");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "Money");

            migrationBuilder.DropTable(
                name: "Currency");
        }
    }
}
