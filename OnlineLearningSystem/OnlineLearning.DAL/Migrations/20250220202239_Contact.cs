using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLearning.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Contact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 20, 20, 22, 37, 990, DateTimeKind.Utc).AddTicks(627),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 20, 13, 29, 24, 618, DateTimeKind.Utc).AddTicks(6130));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ff320838-db8d-45e9-85b5-17c6017f5470", "AQAAAAIAAYagAAAAEIbeRqs2MJjdyDC4RqRzC+GsFX0zqUzpDzgrZPGp/tP3bRteiuLjXlZpLAm1n4PETw==", "ac0a270a-1d2f-4976-87e2-6a82f90d9df5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 20, 13, 29, 24, 618, DateTimeKind.Utc).AddTicks(6130),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 20, 20, 22, 37, 990, DateTimeKind.Utc).AddTicks(627));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af1b4563-6409-4bb0-b1ec-71f96f5b5f5b", "AQAAAAIAAYagAAAAEKW55GTcCDgT3vvZtnrp4VfuGZ2saLdK00aGhYiVJng5i85t9nsKRljVPpQyc6yUhA==", "14cc6fdf-7feb-4a9a-9708-132fb4672c8f" });
        }
    }
}
