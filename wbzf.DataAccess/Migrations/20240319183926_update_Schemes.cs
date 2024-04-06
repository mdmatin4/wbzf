using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wbzf.DataAccess.Migrations
{
    public partial class update_Schemes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image_Url",
                table: "Schemes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image_Url",
                table: "Schemes");
        }
    }
}
