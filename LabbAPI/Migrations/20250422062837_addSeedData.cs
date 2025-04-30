using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LabbAPI.Migrations
{
    /// <inheritdoc />
    public partial class addSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Interest",
                columns: new[] { "Id", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Loves to code in C# and JavaScript.", "Coding" },
                    { 2, "Enjoys both competitive and casual gaming.", "Gaming" },
                    { 3, "Plays the guitar and enjoys rock music.", "Music" },
                    { 4, "Records videos for fun.", "Video" },
                    { 5, "Loves to exercise aims to becomes the next Arnold.", "Exercise" }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Telefonnummer" },
                values: new object[,]
                {
                    { 1, "kim@example.com", "Kim", "Andersson", "0701234560" },
                    { 2, "sara@example.com", "Sara", "Nilsson", "0701234561" },
                    { 3, "kalle@example.com", "Kalle", "Johansson", "0701234562" },
                    { 4, "josefine@example.com", "Josefine", "Svärd", "0701234563" },
                    { 5, "max@example.com", "Max", "Bengtsson", "0701234564" }
                });

            migrationBuilder.InsertData(
                table: "PersonInterest",
                columns: new[] { "Id", "InterestId", "PersonId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 2 },
                    { 4, 4, 2 },
                    { 5, 3, 3 },
                    { 6, 5, 4 },
                    { 7, 2, 5 },
                    { 8, 1, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PersonInterest",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PersonInterest",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PersonInterest",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PersonInterest",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PersonInterest",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PersonInterest",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PersonInterest",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PersonInterest",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Interest",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Interest",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Interest",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Interest",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Interest",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
