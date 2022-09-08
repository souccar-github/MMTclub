using Microsoft.EntityFrameworkCore.Migrations;

namespace Ahc.Club.Migrations
{
    public partial class Add_From_To_Point : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Point",
                table: "Levels");

            migrationBuilder.AddColumn<int>(
                name: "FromPoint",
                table: "Levels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToPoint",
                table: "Levels",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromPoint",
                table: "Levels");

            migrationBuilder.DropColumn(
                name: "ToPoint",
                table: "Levels");

            migrationBuilder.AddColumn<int>(
                name: "Point",
                table: "Levels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
