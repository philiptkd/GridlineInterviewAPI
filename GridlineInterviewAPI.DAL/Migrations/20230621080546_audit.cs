using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GridlineInterviewAPI.DAL.Migrations
{
    /// <inheritdoc />
    public partial class audit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "Audit_Created",
                table: "Trucks",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Audit_Modified",
                table: "Trucks",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Audit_Created",
                table: "Drivers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Audit_Modified",
                table: "Drivers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Audit_Created",
                table: "Trucks");

            migrationBuilder.DropColumn(
                name: "Audit_Modified",
                table: "Trucks");

            migrationBuilder.DropColumn(
                name: "Audit_Created",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "Audit_Modified",
                table: "Drivers");

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
    }
}
