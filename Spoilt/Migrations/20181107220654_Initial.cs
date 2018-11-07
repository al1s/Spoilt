using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Spoilt.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Plot = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    Poster = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Spoilers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MovieID = table.Column<string>(nullable: true),
                    SpoilerText = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Votes = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spoilers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Spoilers_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MovieID = table.Column<string>(nullable: true),
                    SpoilerID = table.Column<int>(nullable: false),
                    UserSessionID = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Votes_Sessions_UserSessionID",
                        column: x => x.UserSessionID,
                        principalTable: "Sessions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Spoilers_MovieID",
                table: "Spoilers",
                column: "MovieID");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_UserSessionID",
                table: "Votes",
                column: "UserSessionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spoilers");

            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Sessions");
        }
    }
}
