using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wbzf.DataAccess.Migrations
{
    public partial class addOrderToGalleryCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "galleryCategories",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "galleryCategories");
        }
    }
}
