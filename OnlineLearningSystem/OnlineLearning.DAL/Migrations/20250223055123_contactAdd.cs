using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineLearning.DAL.Migrations
{
    /// <inheritdoc />
    public partial class contactAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 23, 5, 51, 23, 49, DateTimeKind.Utc).AddTicks(2863),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 22, 16, 51, 1, 476, DateTimeKind.Utc).AddTicks(9320));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "08478ea7-616b-4742-9434-9a419c9c02d8", "AQAAAAIAAYagAAAAECbfk67kUIT2M5Zq2BeDnThABu0TfQqvGott8+cDLK3idehZOfWv3dNfvtPOwC3w5w==", "86516931-1c78-4d7f-8855-2e6bf4bc1788" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Contacts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 22, 16, 51, 1, 476, DateTimeKind.Utc).AddTicks(9320),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 23, 5, 51, 23, 49, DateTimeKind.Utc).AddTicks(2863));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "90f58f47-7bd6-4005-b6ee-e40f632a8fc3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c9cca19b-1048-4918-8f90-4d26ad6f6be0", "AQAAAAIAAYagAAAAEHmZFzJPwZb06vFvM9o4AfVcvTdmw5uzrM9xNhk9rjEAeLQi/Bm2Sr6wzsq9FGwuPw==", "2fa89741-7570-4671-bfc8-51bef11afbdf" });
        }
    }
}
