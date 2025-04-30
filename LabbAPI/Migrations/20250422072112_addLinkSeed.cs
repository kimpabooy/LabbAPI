using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LabbAPI.Migrations
{
    /// <inheritdoc />
    public partial class addLinkSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Link",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonInterestId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Link_PersonInterest_PersonInterestId",
                        column: x => x.PersonInterestId,
                        principalTable: "PersonInterest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Link",
                columns: new[] { "Id", "PersonInterestId", "Url" },
                values: new object[,]
                {
                    { 1, 1, "https://leetcode.com/problemset/" },
                    { 2, 2, "https://store.epicgames.com/en-US/" },
                    { 3, 3, "https://open.spotify.com/" },
                    { 4, 4, "https://www.youtube.com/" },
                    { 5, 5, "https://open.spotify.com/" },
                    { 6, 6, "https://nordicwellness.se/trana/" },
                    { 7, 7, "https://store.epicgames.com/en-US/" },
                    { 8, 8, "https://leetcode.com/problemset/" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Link_PersonInterestId",
                table: "Link",
                column: "PersonInterestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Link");
        }
    }
}
