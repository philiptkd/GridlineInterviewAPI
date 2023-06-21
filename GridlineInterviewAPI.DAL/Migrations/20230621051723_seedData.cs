using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GridlineInterviewAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Alice", "Smith" },
                    { 2, "Bob", "Jones" }
                });

            migrationBuilder.InsertData(
                table: "Trucks",
                columns: new[] { "Id", "Make", "Model", "Year" },
                values: new object[,]
                {
                    { 1, "Toyota", "BigTruck", 0 },
                    { 2, "Ford", "HugeTruck", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trucks",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
