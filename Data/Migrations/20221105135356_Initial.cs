using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fname = table.Column<string>(maxLength: 30, nullable: true),
                    Lname = table.Column<string>(maxLength: 50, nullable: true),
                    NationalID = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneBook",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNo = table.Column<string>(maxLength: 11, nullable: true),
                    PhoneBook_UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneBook", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneBook_User_PhoneBook_UserId",
                        column: x => x.PhoneBook_UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhoneBook_PhoneBook_UserId",
                table: "PhoneBook",
                column: "PhoneBook_UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneBook");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
