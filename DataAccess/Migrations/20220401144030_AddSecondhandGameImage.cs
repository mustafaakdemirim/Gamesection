using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddSecondhandGameImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SecondhandGameImage",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Active = table.Column<bool>(nullable: false),
                    Deleted = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Updated = table.Column<DateTime>(nullable: false),
                    ImageURL = table.Column<string>(nullable: true),
                    SecondhandGameID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecondhandGameImage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SecondhandGameImage_SecondhandGame_SecondhandGameID",
                        column: x => x.SecondhandGameID,
                        principalTable: "SecondhandGame",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_SecondhandGameImage_SecondhandGameID",
                table: "SecondhandGameImage",
                column: "SecondhandGameID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecondhandGameImage");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "5092c677-dab8-41f6-98d7-8f70171aa367");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "148c81d3-89c8-476d-ba42-b6c85396dd81");
        }
    }
}
