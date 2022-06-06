using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddSecondhandGameCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameCategory_SecondhandGame_SecondhandGameID",
                table: "GameCategory");

            migrationBuilder.DropIndex(
                name: "IX_GameCategory_SecondhandGameID",
                table: "GameCategory");

            migrationBuilder.DropColumn(
                name: "SecondhandGameID",
                table: "GameCategory");

            migrationBuilder.CreateTable(
                name: "SecondhandGameCategory",
                columns: table => new
                {
                    SecondhandGameID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecondhandGameCategory", x => new { x.CategoryID, x.SecondhandGameID });
                    table.ForeignKey(
                        name: "FK_SecondhandGameCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SecondhandGameCategory_SecondhandGame_SecondhandGameID",
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
                value: "e214dc88-3dd2-4b2f-a946-a87526f11dbd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "0036b6bf-54d7-40d1-9621-203fe7648ff7");

            migrationBuilder.CreateIndex(
                name: "IX_SecondhandGameCategory_SecondhandGameID",
                table: "SecondhandGameCategory",
                column: "SecondhandGameID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SecondhandGameCategory");

            migrationBuilder.AddColumn<int>(
                name: "SecondhandGameID",
                table: "GameCategory",
                type: "int",
                nullable: true);

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
                name: "IX_GameCategory_SecondhandGameID",
                table: "GameCategory",
                column: "SecondhandGameID");

            migrationBuilder.AddForeignKey(
                name: "FK_GameCategory_SecondhandGame_SecondhandGameID",
                table: "GameCategory",
                column: "SecondhandGameID",
                principalTable: "SecondhandGame",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
