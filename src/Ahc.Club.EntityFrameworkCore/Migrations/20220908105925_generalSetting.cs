using Microsoft.EntityFrameworkCore.Migrations;

namespace Ahc.Club.Migrations
{
    public partial class generalSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "GeneralSettings");

            migrationBuilder.AddColumn<string>(
                name: "MobilePhone",
                table: "GeneralSettings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MobilePhone",
                table: "GeneralSettings");

            migrationBuilder.AddColumn<string>(
                name: "Twitter",
                table: "GeneralSettings",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
