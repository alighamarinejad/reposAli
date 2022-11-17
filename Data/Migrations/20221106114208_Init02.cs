using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Init02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneBook_User_UserId",
                table: "PhoneBook");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "PhoneBook",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneBook_User_UserId",
                table: "PhoneBook",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneBook_User_UserId",
                table: "PhoneBook");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "PhoneBook",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneBook_User_UserId",
                table: "PhoneBook",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
