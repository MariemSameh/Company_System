using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Company_System.Migrations
{
    /// <inheritdoc />
    public partial class seedingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Human Resources Department", "HR" },
                    { 2, "Information Technology Department", "IT" },
                    { 3, "Finance Department", "Finance" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DeptId", "Email", "JoinDate", "Name", "Password", "PhoneNumber", "Salary" },
                values: new object[,]
                {
                    { 8080, 1, "Sara@company.com", new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sara Youssef", "Sara@1234", "01345678901", 9000.00m },
                    { 101011, 2, "mona@company.com", new DateTime(2022, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mona Said", "Mona@123", "01123456789", 9500.00m },
                    { 123456, 3, "hassan@company.com", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hassan Omar", "Hassan789!", "01234567890", 11000.00m },
                    { 303011, 1, "ali@company.com", new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ali Ahmed", "Ali12345", "01012345678", 8000.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8080);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 101011);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 123456);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 303011);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
