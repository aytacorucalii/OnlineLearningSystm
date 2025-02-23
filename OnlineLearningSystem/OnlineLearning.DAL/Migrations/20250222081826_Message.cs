using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLearning.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Message : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "Contacts",
                newName: "UserRole");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Contacts",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Contacts",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Contacts",
                newName: "Comment");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 22, 8, 18, 25, 551, DateTimeKind.Utc).AddTicks(8887),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 21, 18, 22, 44, 936, DateTimeKind.Utc).AddTicks(948));

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Contacts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "514be1c9-fe18-43ea-be4a-3bb66e7e947e", "AQAAAAIAAYagAAAAEHhwZxrlVmb8WukpY1b4Bv9rkz9+hHdvyy5S9EyTq+VE44Q+FpvYMxAGD1bbg6NrSg==", "9913e65c-0714-459e-8473-c921f514d288" });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CourseId",
                table: "Contacts",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Courses_CourseId",
                table: "Contacts",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Courses_CourseId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_CourseId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "UserRole",
                table: "Contacts",
                newName: "Subject");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Contacts",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Contacts",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "Contacts",
                newName: "FullName");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 21, 18, 22, 44, 936, DateTimeKind.Utc).AddTicks(948),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 22, 8, 18, 25, 551, DateTimeKind.Utc).AddTicks(8887));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86d4d04d-5968-4f44-839f-8eb8697e92fb", "AQAAAAIAAYagAAAAEM9zAk+n3BurAPhOdzXlDRoz+34orKgCPkX6WKHNTFMqGndgcTcKu9gQqLFImsks5w==", "f34ca1b5-fb35-467a-9c13-58f10c3ee37c" });
        }
    }
}
