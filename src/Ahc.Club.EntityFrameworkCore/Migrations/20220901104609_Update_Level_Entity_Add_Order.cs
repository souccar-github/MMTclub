using Microsoft.EntityFrameworkCore.Migrations;

namespace Ahc.Club.Migrations
{
    public partial class Update_Level_Entity_Add_Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Received",
                table: "UserGifts");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "UserGifts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Levels",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "UserGifts");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Levels");

            migrationBuilder.AddColumn<bool>(
                name: "Received",
                table: "UserGifts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
