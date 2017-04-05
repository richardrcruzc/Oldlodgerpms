using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LodgerPms.DepartmentsDataLayer.Migrations
{
    public partial class deptogroupType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "DepartmentGroups",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "DepartmentGroups",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "DepartmentGroups");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "DepartmentGroups");
        }
    }
}
