using Microsoft.EntityFrameworkCore.Migrations;

namespace Spoilt.Migrations
{
    public partial class local : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Spoilers",
                newName: "Created");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Spoilers",
                newName: "CreatedAt");
        }
    }
}
