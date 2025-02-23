using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLearning.DAL.Migrations
{
    /// <inheritdoc />
    public partial class OneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_Courses_CourseId1",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_CourseId1",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "CourseId1",
                table: "Teachers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 12, 14, 58, 33, 186, DateTimeKind.Utc).AddTicks(7593),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 12, 14, 47, 40, 439, DateTimeKind.Utc).AddTicks(316));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5fc2ea84-4f50-4ca4-9ff4-b946ed387529", "AQAAAAIAAYagAAAAEMCMSHEnMGeFUN8I4+4KXbCb/rmUO38RufLhZrCvoGDgHlAQQgotv5iPrHcJBpYc7g==", "9851f6d0-0645-4414-9e65-4159917c96d8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Teachers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CourseId1",
                table: "Teachers",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 12, 14, 47, 40, 439, DateTimeKind.Utc).AddTicks(316),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 12, 14, 58, 33, 186, DateTimeKind.Utc).AddTicks(7593));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f29378b-3bef-43d9-a5b8-b89043b4b9ad", "AQAAAAIAAYagAAAAEGYTS+Adx5v5i3E7EO9Yyu8eGd94E7n++jjQ9PWCcc3Xo8yQOAgOAqsEUKmxinadeA==", "0e931057-db60-436d-b1f1-f3328b9fd9c4" });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_CourseId1",
                table: "Teachers",
                column: "CourseId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_Courses_CourseId1",
                table: "Teachers",
                column: "CourseId1",
                principalTable: "Courses",
                principalColumn: "Id");
        }
    }
}
