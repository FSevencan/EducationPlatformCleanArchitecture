using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddExamIdTouserAnswers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ExamId",
                table: "UserAnswers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 140, 175, 9, 189, 154, 89, 222, 17, 201, 246, 162, 75, 80, 162, 153, 142, 72, 59, 59, 66, 174, 205, 102, 133, 207, 186, 168, 43, 105, 253, 152, 218, 92, 7, 132, 20, 10, 208, 130, 78, 152, 244, 162, 22, 223, 208, 197, 192, 81, 169, 246, 190, 181, 209, 244, 18, 67, 35, 159, 20, 156, 232, 29, 246 }, new byte[] { 135, 65, 73, 229, 52, 60, 202, 180, 27, 255, 32, 240, 205, 72, 143, 157, 26, 206, 76, 73, 112, 170, 180, 32, 118, 211, 29, 254, 215, 119, 29, 53, 86, 127, 200, 109, 6, 207, 113, 104, 241, 166, 143, 191, 63, 248, 121, 39, 248, 235, 28, 88, 42, 23, 46, 166, 185, 190, 151, 107, 174, 238, 83, 145, 30, 15, 27, 244, 223, 89, 170, 162, 228, 24, 223, 96, 221, 202, 47, 85, 177, 73, 130, 209, 69, 192, 29, 12, 11, 204, 169, 15, 200, 250, 205, 9, 233, 85, 104, 99, 204, 124, 51, 145, 102, 254, 234, 77, 95, 173, 91, 97, 51, 241, 69, 25, 188, 128, 84, 224, 208, 217, 29, 48, 165, 27, 124, 102 } });

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_ExamId",
                table: "UserAnswers",
                column: "ExamId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_Exams_ExamId",
                table: "UserAnswers",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_Exams_ExamId",
                table: "UserAnswers");

            migrationBuilder.DropIndex(
                name: "IX_UserAnswers_ExamId",
                table: "UserAnswers");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "UserAnswers");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 104, 55, 141, 54, 150, 68, 146, 6, 2, 61, 97, 78, 166, 243, 149, 200, 59, 112, 187, 136, 195, 53, 222, 10, 71, 242, 217, 143, 130, 124, 112, 229, 45, 42, 154, 236, 214, 239, 152, 197, 234, 6, 130, 150, 76, 175, 51, 54, 165, 176, 112, 66, 217, 85, 181, 253, 169, 78, 143, 2, 24, 38, 32, 65 }, new byte[] { 168, 240, 87, 198, 213, 200, 16, 6, 18, 118, 253, 151, 62, 189, 93, 158, 117, 33, 119, 232, 34, 102, 123, 208, 184, 175, 45, 95, 39, 245, 78, 203, 11, 139, 100, 64, 74, 184, 252, 202, 21, 11, 185, 16, 193, 136, 151, 209, 231, 100, 131, 62, 1, 89, 54, 87, 48, 56, 156, 255, 141, 186, 106, 222, 227, 2, 241, 8, 118, 108, 76, 171, 94, 103, 26, 133, 99, 117, 154, 238, 165, 156, 70, 65, 158, 28, 251, 132, 105, 209, 115, 153, 228, 131, 63, 55, 177, 26, 242, 72, 4, 68, 182, 87, 23, 106, 144, 5, 244, 147, 60, 238, 127, 112, 135, 139, 198, 106, 253, 146, 47, 231, 241, 51, 138, 253, 247, 231 } });
        }
    }
}
