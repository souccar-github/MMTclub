using Microsoft.EntityFrameworkCore.Migrations;

namespace Ahc.Club.Migrations
{
    public partial class Create_QrCodeRequest_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QrCodeRequest_Products_ProductId",
                table: "QrCodeRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_QrCodes_QrCodeRequest_QrCodeRequestId",
                table: "QrCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QrCodeRequest",
                table: "QrCodeRequest");

            migrationBuilder.RenameTable(
                name: "QrCodeRequest",
                newName: "QrCodeRequests");

            migrationBuilder.RenameIndex(
                name: "IX_QrCodeRequest_ProductId",
                table: "QrCodeRequests",
                newName: "IX_QrCodeRequests_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QrCodeRequests",
                table: "QrCodeRequests",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QrCodeRequests_Products_ProductId",
                table: "QrCodeRequests",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QrCodes_QrCodeRequests_QrCodeRequestId",
                table: "QrCodes",
                column: "QrCodeRequestId",
                principalTable: "QrCodeRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QrCodeRequests_Products_ProductId",
                table: "QrCodeRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_QrCodes_QrCodeRequests_QrCodeRequestId",
                table: "QrCodes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_QrCodeRequests",
                table: "QrCodeRequests");

            migrationBuilder.RenameTable(
                name: "QrCodeRequests",
                newName: "QrCodeRequest");

            migrationBuilder.RenameIndex(
                name: "IX_QrCodeRequests_ProductId",
                table: "QrCodeRequest",
                newName: "IX_QrCodeRequest_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QrCodeRequest",
                table: "QrCodeRequest",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QrCodeRequest_Products_ProductId",
                table: "QrCodeRequest",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QrCodes_QrCodeRequest_QrCodeRequestId",
                table: "QrCodes",
                column: "QrCodeRequestId",
                principalTable: "QrCodeRequest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
