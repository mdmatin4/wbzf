using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wbzf.DataAccess.Migrations
{
    public partial class newUserDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateofBirth",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostOffice",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vill",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "bankAcNo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "bankBranchName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "bankIFSC",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "bankName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "familyIncome",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "guardianIncome",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "guardianName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "guardianOccupation",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "occupation",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "parentType",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateofBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PostOffice",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Vill",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "bankAcNo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "bankBranchName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "bankIFSC",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "bankName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "familyIncome",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "guardianIncome",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "guardianName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "guardianOccupation",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "occupation",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "parentType",
                table: "AspNetUsers");
        }
    }
}
