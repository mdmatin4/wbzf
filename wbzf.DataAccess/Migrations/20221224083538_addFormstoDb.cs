using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wbzf.DataAccess.Migrations
{
    public partial class addFormstoDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "coachingForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    application_no = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    exam_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    aadharno = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    guardain_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    guardain_occupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    guardian_Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    present_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    permanant_address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Whatsappno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    family_income = table.Column<int>(type: "int", nullable: false),
                    Academic_Qualification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    other_qualification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    currently_working = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_appeared_bafore = table.Column<bool>(type: "bit", nullable: false),
                    attempt_year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_from_zakat_category = table.Column<bool>(type: "bit", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coachingForms", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "coachingForms");
        }
    }
}
