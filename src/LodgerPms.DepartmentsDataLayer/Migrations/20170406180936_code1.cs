using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LodgerPms.DepartmentsDataLayer.Migrations
{
    public partial class code1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentGroups_Money_CurrencyId",
                table: "DepartmentGroups");

            migrationBuilder.DropIndex(
                name: "IX_DepartmentGroups_CurrencyId",
                table: "DepartmentGroups");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "DepartmentGroups");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "DepartmentGroups");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CurrencyId",
                table: "DepartmentGroups",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "DepartmentGroups",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentGroups_CurrencyId",
                table: "DepartmentGroups",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentGroups_Money_CurrencyId",
                table: "DepartmentGroups",
                column: "CurrencyId",
                principalTable: "Money",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
