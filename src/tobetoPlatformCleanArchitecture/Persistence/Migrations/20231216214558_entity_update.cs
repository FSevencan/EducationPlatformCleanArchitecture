using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class entity_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SectionAbouts_SectionId",
                table: "SectionAbouts");

            migrationBuilder.DropColumn(
                name: "SectionAboutId",
                table: "Sections");

            migrationBuilder.AlterColumn<double>(
                name: "EstimatedDuration",
                table: "SectionAbouts",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Time",
                table: "Lessons",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Exams",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalTime",
                table: "Courses",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 98, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AppUsers.Admin", null },
                    { 99, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AppUsers.Read", null },
                    { 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AppUsers.Write", null },
                    { 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AppUsers.Add", null },
                    { 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AppUsers.Update", null },
                    { 103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "AppUsers.Delete", null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 251, 27, 139, 195, 154, 97, 133, 106, 172, 154, 143, 96, 41, 144, 141, 133, 124, 212, 101, 136, 17, 204, 95, 107, 218, 249, 180, 11, 53, 39, 185, 156, 249, 62, 63, 15, 241, 83, 188, 93, 207, 206, 52, 60, 39, 61, 36, 178, 98, 138, 205, 200, 184, 50, 149, 70, 150, 79, 99, 156, 180, 202, 72, 131 }, new byte[] { 248, 83, 60, 102, 0, 37, 87, 193, 6, 165, 55, 134, 1, 42, 234, 122, 178, 209, 51, 69, 85, 224, 224, 141, 149, 63, 112, 228, 204, 231, 108, 176, 79, 173, 52, 149, 40, 231, 228, 76, 71, 105, 178, 175, 136, 20, 130, 31, 192, 194, 86, 38, 8, 242, 223, 171, 95, 218, 101, 232, 154, 91, 223, 45, 123, 35, 74, 73, 255, 85, 104, 235, 15, 169, 100, 22, 16, 53, 221, 130, 232, 162, 134, 207, 185, 253, 242, 55, 220, 14, 96, 116, 88, 244, 97, 46, 217, 149, 7, 62, 170, 228, 225, 88, 156, 88, 225, 216, 223, 29, 95, 144, 232, 73, 56, 210, 237, 26, 138, 171, 20, 37, 233, 73, 4, 147, 108, 141 } });

            migrationBuilder.CreateIndex(
                name: "IX_SectionAbouts_SectionId",
                table: "SectionAbouts",
                column: "SectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SectionAbouts_SectionId",
                table: "SectionAbouts");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.AddColumn<Guid>(
                name: "SectionAboutId",
                table: "Sections",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "EstimatedDuration",
                table: "SectionAbouts",
                type: "time",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Time",
                table: "Lessons",
                type: "time",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "Exams",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "TotalTime",
                table: "Courses",
                type: "time",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 106, 28, 167, 160, 148, 157, 204, 222, 190, 118, 21, 144, 27, 126, 204, 69, 167, 11, 125, 43, 202, 247, 53, 52, 109, 2, 11, 230, 112, 235, 163, 115, 134, 70, 80, 15, 182, 250, 52, 31, 249, 130, 226, 98, 59, 74, 118, 248, 58, 53, 116, 47, 204, 162, 181, 202, 171, 157, 236, 119, 247, 19, 240, 231 }, new byte[] { 120, 37, 193, 175, 111, 172, 182, 34, 242, 13, 227, 216, 230, 217, 17, 153, 198, 72, 19, 248, 71, 118, 68, 149, 225, 121, 30, 229, 202, 241, 20, 251, 121, 37, 142, 92, 23, 118, 15, 136, 130, 27, 238, 46, 170, 182, 67, 115, 215, 198, 210, 15, 233, 189, 181, 227, 117, 111, 192, 195, 163, 88, 49, 137, 183, 241, 168, 36, 86, 162, 64, 47, 146, 20, 97, 209, 103, 122, 35, 147, 55, 199, 132, 186, 89, 130, 191, 235, 72, 191, 241, 228, 28, 78, 211, 184, 57, 38, 157, 59, 53, 175, 197, 230, 189, 241, 15, 186, 207, 30, 37, 169, 25, 5, 15, 7, 176, 160, 56, 56, 206, 5, 216, 185, 170, 248, 79, 47 } });

            migrationBuilder.CreateIndex(
                name: "IX_SectionAbouts_SectionId",
                table: "SectionAbouts",
                column: "SectionId",
                unique: true);
        }
    }
}
