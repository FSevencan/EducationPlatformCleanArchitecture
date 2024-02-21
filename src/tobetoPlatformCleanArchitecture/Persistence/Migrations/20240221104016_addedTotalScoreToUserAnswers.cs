using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addedTotalScoreToUserAnswers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerText",
                table: "UserAnswers");

            migrationBuilder.AddColumn<int>(
                name: "TotalScore",
                table: "UserAnswers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 85, 187, 163, 155, 213, 226, 188, 198, 43, 71, 120, 76, 43, 60, 69, 66, 72, 50, 189, 133, 147, 143, 70, 62, 94, 191, 94, 190, 30, 109, 240, 64, 21, 93, 140, 8, 152, 221, 9, 49, 194, 28, 189, 36, 226, 122, 243, 243, 215, 244, 237, 136, 115, 150, 24, 33, 160, 106, 4, 139, 161, 165, 85, 161 }, new byte[] { 85, 57, 41, 246, 176, 5, 121, 60, 5, 181, 232, 156, 10, 199, 189, 202, 197, 36, 29, 102, 126, 211, 191, 192, 213, 116, 15, 196, 234, 139, 26, 29, 73, 139, 244, 103, 188, 181, 254, 186, 237, 70, 100, 168, 59, 205, 77, 186, 103, 219, 27, 18, 145, 62, 176, 100, 80, 30, 12, 233, 98, 239, 146, 96, 56, 215, 14, 58, 243, 115, 241, 99, 117, 181, 45, 24, 85, 195, 147, 156, 74, 29, 137, 165, 195, 196, 212, 162, 154, 181, 213, 155, 182, 151, 122, 187, 59, 99, 36, 103, 83, 210, 116, 24, 33, 93, 176, 142, 150, 26, 75, 141, 145, 14, 39, 38, 25, 88, 34, 210, 104, 35, 133, 52, 112, 114, 166, 109 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalScore",
                table: "UserAnswers");

            migrationBuilder.AddColumn<string>(
                name: "AnswerText",
                table: "UserAnswers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 235, 119, 133, 111, 245, 161, 237, 71, 213, 252, 85, 106, 81, 235, 189, 106, 135, 207, 177, 251, 125, 119, 113, 222, 209, 17, 224, 48, 159, 49, 48, 96, 234, 50, 215, 99, 200, 179, 31, 220, 160, 174, 12, 27, 203, 67, 121, 37, 206, 35, 20, 9, 82, 217, 168, 181, 149, 105, 112, 174, 148, 226, 243, 103 }, new byte[] { 167, 41, 71, 81, 91, 120, 119, 123, 19, 92, 93, 191, 9, 189, 3, 25, 113, 145, 56, 231, 175, 142, 218, 126, 183, 241, 225, 151, 198, 155, 69, 97, 196, 167, 195, 103, 52, 255, 191, 246, 114, 43, 9, 103, 76, 13, 178, 116, 137, 254, 146, 52, 248, 226, 16, 150, 204, 170, 36, 127, 27, 63, 159, 47, 199, 199, 29, 55, 131, 198, 61, 60, 150, 162, 19, 50, 167, 60, 131, 33, 10, 245, 72, 245, 4, 184, 39, 242, 87, 143, 70, 107, 157, 38, 97, 128, 250, 54, 65, 184, 233, 159, 144, 215, 157, 251, 58, 196, 234, 98, 231, 193, 34, 142, 89, 248, 53, 2, 243, 188, 193, 158, 194, 146, 13, 50, 48, 114 } });
        }
    }
}
