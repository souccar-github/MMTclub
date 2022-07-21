using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ahc.Club.Migrations
{
    public partial class Update_Entities2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QrCodeRequestId",
                table: "QrCodes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "QrCodeRequest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QrCodeRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QrCodeRequest_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QrCodes_QrCodeRequestId",
                table: "QrCodes",
                column: "QrCodeRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_QrCodeRequest_ProductId",
                table: "QrCodeRequest",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_QrCodes_QrCodeRequest_QrCodeRequestId",
                table: "QrCodes",
                column: "QrCodeRequestId",
                principalTable: "QrCodeRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QrCodes_QrCodeRequest_QrCodeRequestId",
                table: "QrCodes");

            migrationBuilder.DropTable(
                name: "QrCodeRequest");

            migrationBuilder.DropIndex(
                name: "IX_QrCodes_QrCodeRequestId",
                table: "QrCodes");

            migrationBuilder.DropColumn(
                name: "QrCodeRequestId",
                table: "QrCodes");
        }
    }
}
