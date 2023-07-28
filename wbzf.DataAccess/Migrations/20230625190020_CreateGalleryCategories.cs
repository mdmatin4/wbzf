using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wbzf.DataAccess.Migrations
{
    public partial class CreateGalleryCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "gallery",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "galleryCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_galleryCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_gallery_CategoryId",
                table: "gallery",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_gallery_galleryCategories_CategoryId",
                table: "gallery",
                column: "CategoryId",
                principalTable: "galleryCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_gallery_galleryCategories_CategoryId",
                table: "gallery");

            migrationBuilder.DropTable(
                name: "galleryCategories");

            migrationBuilder.DropIndex(
                name: "IX_gallery_CategoryId",
                table: "gallery");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "gallery");
        }
    }
}
