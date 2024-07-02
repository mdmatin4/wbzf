using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wbzf.DataAccess.Migrations
{
    public partial class updateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Claim_Amount",
                table: "application_register",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Hospital_admission_receipt_url",
                table: "application_register",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Insurance_Claimed_date",
                table: "application_register",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Insurance_Name",
                table: "application_register",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Medicine_bill_url",
                table: "application_register",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Past_Scholar_date",
                table: "application_register",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Claim_Amount",
                table: "application_register");

            migrationBuilder.DropColumn(
                name: "Hospital_admission_receipt_url",
                table: "application_register");

            migrationBuilder.DropColumn(
                name: "Insurance_Claimed_date",
                table: "application_register");

            migrationBuilder.DropColumn(
                name: "Insurance_Name",
                table: "application_register");

            migrationBuilder.DropColumn(
                name: "Medicine_bill_url",
                table: "application_register");

            migrationBuilder.DropColumn(
                name: "Past_Scholar_date",
                table: "application_register");
        }
    }
}
