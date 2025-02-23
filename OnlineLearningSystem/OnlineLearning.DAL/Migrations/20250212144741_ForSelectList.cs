using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLearning.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ForSelectList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 12, 14, 47, 40, 439, DateTimeKind.Utc).AddTicks(316),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 12, 14, 42, 5, 194, DateTimeKind.Utc).AddTicks(1765));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f29378b-3bef-43d9-a5b8-b89043b4b9ad", "AQAAAAIAAYagAAAAEGYTS+Adx5v5i3E7EO9Yyu8eGd94E7n++jjQ9PWCcc3Xo8yQOAgOAqsEUKmxinadeA==", "0e931057-db60-436d-b1f1-f3328b9fd9c4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 12, 14, 42, 5, 194, DateTimeKind.Utc).AddTicks(1765),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 12, 14, 47, 40, 439, DateTimeKind.Utc).AddTicks(316));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54d7f551-3901-479d-8112-a5003b3ce37d", "AQAAAAIAAYagAAAAEDRY54dsI50FJdyVdwYWKRETTjaVQcF0ZkPdox64dP1Lpca2WZRnpRsm1BfQWTxFhg==", "2b640e79-41ad-4a26-8267-34c85033b209" });
        }
    }
}
