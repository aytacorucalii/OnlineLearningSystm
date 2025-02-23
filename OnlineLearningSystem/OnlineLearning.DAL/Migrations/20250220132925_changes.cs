using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLearning.DAL.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 20, 13, 29, 24, 618, DateTimeKind.Utc).AddTicks(6130),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 13, 21, 30, 26, 250, DateTimeKind.Utc).AddTicks(5295));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af1b4563-6409-4bb0-b1ec-71f96f5b5f5b", "AQAAAAIAAYagAAAAEKW55GTcCDgT3vvZtnrp4VfuGZ2saLdK00aGhYiVJng5i85t9nsKRljVPpQyc6yUhA==", "14cc6fdf-7feb-4a9a-9708-132fb4672c8f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 13, 21, 30, 26, 250, DateTimeKind.Utc).AddTicks(5295),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 20, 13, 29, 24, 618, DateTimeKind.Utc).AddTicks(6130));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7dc3fe9f-a9bc-4cad-921d-0feb882a12ce", "AQAAAAIAAYagAAAAEAZUns1OJyB2VVNF2bwTa/G7pofDhbKoDNJak5oLwVxeAWqqvourObOMBD57LYisjg==", "106b52e1-3e4d-4bdd-9751-b8b1550227e7" });
        }
    }
}
