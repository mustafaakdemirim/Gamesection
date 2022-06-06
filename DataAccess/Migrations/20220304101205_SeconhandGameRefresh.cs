using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class SeconhandGameRefresh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SecondhandGameID",
                table: "GameImage",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecondhandGameID",
                table: "GameCategory",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecondhandGameID",
                table: "Cart",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SecondhandGame",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    GameName = table.Column<string>(nullable: true),
                    AddUserID = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Stock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecondhandGame", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "7fc33712-588b-4bee-89be-0c51fd0d90f2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "e9a396ec-ee2b-4635-b434-64946e91b28c");

            migrationBuilder.CreateIndex(
                name: "IX_GameImage_SecondhandGameID",
                table: "GameImage",
                column: "SecondhandGameID");

            migrationBuilder.CreateIndex(
                name: "IX_GameCategory_SecondhandGameID",
                table: "GameCategory",
                column: "SecondhandGameID");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_SecondhandGameID",
                table: "Cart",
                column: "SecondhandGameID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_SecondhandGame_SecondhandGameID",
                table: "Cart",
                column: "SecondhandGameID",
                principalTable: "SecondhandGame",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameCategory_SecondhandGame_SecondhandGameID",
                table: "GameCategory",
                column: "SecondhandGameID",
                principalTable: "SecondhandGame",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GameImage_SecondhandGame_SecondhandGameID",
                table: "GameImage",
                column: "SecondhandGameID",
                principalTable: "SecondhandGame",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_SecondhandGame_SecondhandGameID",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_GameCategory_SecondhandGame_SecondhandGameID",
                table: "GameCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_GameImage_SecondhandGame_SecondhandGameID",
                table: "GameImage");

            migrationBuilder.DropTable(
                name: "SecondhandGame");

            migrationBuilder.DropIndex(
                name: "IX_GameImage_SecondhandGameID",
                table: "GameImage");

            migrationBuilder.DropIndex(
                name: "IX_GameCategory_SecondhandGameID",
                table: "GameCategory");

            migrationBuilder.DropIndex(
                name: "IX_Cart_SecondhandGameID",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "SecondhandGameID",
                table: "GameImage");

            migrationBuilder.DropColumn(
                name: "SecondhandGameID",
                table: "GameCategory");

            migrationBuilder.DropColumn(
                name: "SecondhandGameID",
                table: "Cart");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "97b9ae2f-f0db-42fc-b317-8e2fec527e8c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "56df2cc4-97db-4a95-befd-8b17573cdf08");
        }
    }
}
