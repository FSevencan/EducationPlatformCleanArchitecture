using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatedUserAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_Choices_ChoiceId",
                table: "UserAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_Questions_QuestionId",
                table: "UserAnswers");

            migrationBuilder.DropIndex(
                name: "IX_UserAnswers_ChoiceId",
                table: "UserAnswers");

            migrationBuilder.DropIndex(
                name: "IX_UserAnswers_QuestionId",
                table: "UserAnswers");

            migrationBuilder.DropColumn(
                name: "ChoiceId",
                table: "UserAnswers");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "UserAnswers");

            migrationBuilder.AddColumn<int>(
                name: "CorrectCount",
                table: "UserAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmptyCount",
                table: "UserAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WrongCount",
                table: "UserAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 235, 119, 133, 111, 245, 161, 237, 71, 213, 252, 85, 106, 81, 235, 189, 106, 135, 207, 177, 251, 125, 119, 113, 222, 209, 17, 224, 48, 159, 49, 48, 96, 234, 50, 215, 99, 200, 179, 31, 220, 160, 174, 12, 27, 203, 67, 121, 37, 206, 35, 20, 9, 82, 217, 168, 181, 149, 105, 112, 174, 148, 226, 243, 103 }, new byte[] { 167, 41, 71, 81, 91, 120, 119, 123, 19, 92, 93, 191, 9, 189, 3, 25, 113, 145, 56, 231, 175, 142, 218, 126, 183, 241, 225, 151, 198, 155, 69, 97, 196, 167, 195, 103, 52, 255, 191, 246, 114, 43, 9, 103, 76, 13, 178, 116, 137, 254, 146, 52, 248, 226, 16, 150, 204, 170, 36, 127, 27, 63, 159, 47, 199, 199, 29, 55, 131, 198, 61, 60, 150, 162, 19, 50, 167, 60, 131, 33, 10, 245, 72, 245, 4, 184, 39, 242, 87, 143, 70, 107, 157, 38, 97, 128, 250, 54, 65, 184, 233, 159, 144, 215, 157, 251, 58, 196, 234, 98, 231, 193, 34, 142, 89, 248, 53, 2, 243, 188, 193, 158, 194, 146, 13, 50, 48, 114 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrectCount",
                table: "UserAnswers");

            migrationBuilder.DropColumn(
                name: "EmptyCount",
                table: "UserAnswers");

            migrationBuilder.DropColumn(
                name: "WrongCount",
                table: "UserAnswers");

            migrationBuilder.AddColumn<Guid>(
                name: "ChoiceId",
                table: "UserAnswers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "QuestionId",
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
                name: "IX_UserAnswers_ChoiceId",
                table: "UserAnswers",
                column: "ChoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_QuestionId",
                table: "UserAnswers",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_Choices_ChoiceId",
                table: "UserAnswers",
                column: "ChoiceId",
                principalTable: "Choices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_Questions_QuestionId",
                table: "UserAnswers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
