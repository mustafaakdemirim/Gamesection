using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UpdateSecondhandGameImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameImage_SecondhandGame_SecondhandGameID",
                table: "GameImage");

            migrationBuilder.DropIndex(
                name: "IX_GameImage_SecondhandGameID",
                table: "GameImage");

            migrationBuilder.DropColumn(
                name: "SecondhandGameID",
                table: "GameImage");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "b62e2c2e-c8c3-4f4d-b889-3a04507f9873");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "0a8b4b75-e667-47a1-9447-18140d1ee63a");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SecondhandGameID",
                table: "GameImage",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "6ea0a332-0bc5-450e-8e93-fdf01d397a4d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "d367bbd6-e134-410b-899c-1aa106af6150");

            migrationBuilder.CreateIndex(
                name: "IX_GameImage_SecondhandGameID",
                table: "GameImage",
                column: "SecondhandGameID");

            migrationBuilder.AddForeignKey(
                name: "FK_GameImage_SecondhandGame_SecondhandGameID",
                table: "GameImage",
                column: "SecondhandGameID",
                principalTable: "SecondhandGame",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
