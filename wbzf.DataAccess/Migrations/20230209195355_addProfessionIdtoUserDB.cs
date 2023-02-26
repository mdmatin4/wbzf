using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wbzf.DataAccess.Migrations
{
    public partial class addProfessionIdtoUserDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "guardianOccupation",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "occupation",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "ProfessionId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "guardianOccupationId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_guardianOccupationId",
                table: "AspNetUsers",
                column: "guardianOccupationId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProfessionId",
                table: "AspNetUsers",
                column: "ProfessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_professions_guardianOccupationId",
                table: "AspNetUsers",
                column: "guardianOccupationId",
                principalTable: "professions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_professions_ProfessionId",
                table: "AspNetUsers",
                column: "ProfessionId",
                principalTable: "professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_professions_guardianOccupationId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_professions_ProfessionId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_guardianOccupationId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProfessionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfessionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "guardianOccupationId",
                table: "AspNetUsers");

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
        }
    }
}
