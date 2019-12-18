using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Garage_2._0.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RegNr",
                table: "Vehicle",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "Brand", "Color", "Model", "NumnOfWheels", "RegNr", "TimeOfParking", "Typ" },
                values: new object[,]
                {
                    { 1, "Volvo", "Green", "Stationwagon", 4, "ABC123", new DateTime(2019, 12, 11, 16, 10, 16, 811, DateTimeKind.Local).AddTicks(2490), 0 },
                    { 2, "Scania", "Red", "DoubleDecker", 8, "BCD234", new DateTime(2019, 12, 11, 16, 10, 16, 814, DateTimeKind.Local).AddTicks(4544), 2 },
                    { 3, "Lockheed", "Silver", "DC10", 6, "CDE345", new DateTime(2019, 12, 11, 16, 10, 16, 814, DateTimeKind.Local).AddTicks(4651), 3 },
                    { 4, "Penta", "Brown", "Sailingboat", 0, "DEF456", new DateTime(2019, 12, 11, 16, 10, 16, 814, DateTimeKind.Local).AddTicks(4661), 1 },
                    { 5, "BMW", "Violet", "BladeRunner", 34, "ASD345", new DateTime(1997, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<string>(
                name: "RegNr",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
