using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneBook_User_PhoneBook_UserId",
                table: "PhoneBook");

            migrationBuilder.DropIndex(
                name: "IX_PhoneBook_PhoneBook_UserId",
                table: "PhoneBook");

            migrationBuilder.DropColumn(
                name: "PhoneBook_UserId",
                table: "PhoneBook");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PhoneBook",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhoneBook_UserId",
                table: "PhoneBook",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneBook_User_UserId",
                table: "PhoneBook",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneBook_User_UserId",
                table: "PhoneBook");

            migrationBuilder.DropIndex(
                name: "IX_PhoneBook_UserId",
                table: "PhoneBook");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PhoneBook");

            migrationBuilder.AddColumn<int>(
                name: "PhoneBook_UserId",
                table: "PhoneBook",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhoneBook_PhoneBook_UserId",
                table: "PhoneBook",
                column: "PhoneBook_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneBook_User_PhoneBook_UserId",
                table: "PhoneBook",
                column: "PhoneBook_UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
