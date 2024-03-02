using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PharmacyApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeededDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pharmacies",
                columns: new[] { "PharmacyId", "Address", "City", "CreatedDate", "Name", "NumberOfFilledPrescriptions", "State", "UpdatedDate", "Zip" },
                values: new object[,]
                {
                    { 1L, "150 E Stacy Rd Suite 2400", "Allen", new DateTime(2024, 3, 1, 23, 43, 11, 647, DateTimeKind.Local).AddTicks(7430), "CVS Pharmacy", 0, "TX", new DateTime(2024, 3, 1, 23, 43, 11, 647, DateTimeKind.Local).AddTicks(7480), "75002" },
                    { 2L, "575 E Exchange Pkwy", "Allen", new DateTime(2024, 3, 1, 23, 43, 11, 647, DateTimeKind.Local).AddTicks(7480), "H-E-B Pharmacy", 0, "TX", new DateTime(2024, 3, 1, 23, 43, 11, 647, DateTimeKind.Local).AddTicks(7480), "75002" },
                    { 3L, "730 W Exchange Pkwy", "Allen", new DateTime(2024, 3, 1, 23, 43, 11, 647, DateTimeKind.Local).AddTicks(7480), "Walmart Pharmacy", 0, "TX", new DateTime(2024, 3, 1, 23, 43, 11, 647, DateTimeKind.Local).AddTicks(7480), "75013" },
                    { 4L, "500 E Stacy Rd", "Allen", new DateTime(2024, 3, 1, 23, 43, 11, 647, DateTimeKind.Local).AddTicks(7480), "Walgreens Pharmacy", 0, "TX", new DateTime(2024, 3, 1, 23, 43, 11, 647, DateTimeKind.Local).AddTicks(7490), "75002" },
                    { 5L, "1210 N Greenville Ave", "Allen", new DateTime(2024, 3, 1, 23, 43, 11, 647, DateTimeKind.Local).AddTicks(7490), "Kroger Pharmacy", 0, "TX", new DateTime(2024, 3, 1, 23, 43, 11, 647, DateTimeKind.Local).AddTicks(7490), "75002" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pharmacies",
                keyColumn: "PharmacyId",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Pharmacies",
                keyColumn: "PharmacyId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Pharmacies",
                keyColumn: "PharmacyId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Pharmacies",
                keyColumn: "PharmacyId",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Pharmacies",
                keyColumn: "PharmacyId",
                keyValue: 5L);
        }
    }
}
