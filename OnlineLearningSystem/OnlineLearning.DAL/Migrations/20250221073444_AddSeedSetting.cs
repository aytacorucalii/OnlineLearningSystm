using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineLearning.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 21, 7, 34, 43, 589, DateTimeKind.Utc).AddTicks(6786),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 20, 20, 25, 10, 140, DateTimeKind.Utc).AddTicks(6955));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d2467d8-44b8-43df-b19c-ef068f716f2b", "AQAAAAIAAYagAAAAEESRAvRuWXDc3+YF0opqhGiWzI5bXTuDiN9rUQYquuH9UaYw4pEfKfeDILBaqbU5kA==", "17c97cae-1a0e-42b9-b04d-1dc19714101f" });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "Key", "Value" },
                values: new object[,]
                {
                    { 1, "facebook", "https://www.facebook.com/login" },
                    { 2, "instagram", "https://www.instagram.com/accounts/login/" },
                    { 3, "linkedin", "https://www.linkedin.com/login" },
                    { 4, "twitter", "https://twitter.com/login" },
                    { 5, "youtube", "https://accounts.google.com/ServiceLogin?service=youtube" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 20, 20, 25, 10, 140, DateTimeKind.Utc).AddTicks(6955),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 21, 7, 34, 43, 589, DateTimeKind.Utc).AddTicks(6786));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85b06774-a40f-4f96-8603-660c7460c4d8", "AQAAAAIAAYagAAAAEN6Zd1xsuLUHZAdyC8lm2W0/bP7YpddH3fHDi3lSKgenV4h5TkCqr/C0fsLOn5VKxA==", "45df32a1-c853-427c-9e9b-86f500211e1e" });
        }
    }
}
