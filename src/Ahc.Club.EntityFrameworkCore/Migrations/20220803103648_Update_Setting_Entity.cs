using Microsoft.EntityFrameworkCore.Migrations;

namespace Ahc.Club.Migrations
{
    public partial class Update_Setting_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facbook",
                table: "GeneralSettings");

            migrationBuilder.AddColumn<string>(
                name: "Facebook",
                table: "GeneralSettings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Facebook",
                table: "GeneralSettings");

            migrationBuilder.AddColumn<string>(
                name: "Facbook",
                table: "GeneralSettings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
