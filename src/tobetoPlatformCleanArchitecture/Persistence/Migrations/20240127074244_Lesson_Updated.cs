using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Lesson_Updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Lessons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 115, 228, 230, 74, 90, 91, 140, 214, 5, 133, 100, 55, 37, 155, 59, 107, 204, 118, 248, 51, 144, 94, 165, 43, 144, 7, 18, 224, 143, 169, 162, 251, 220, 83, 173, 115, 167, 112, 221, 200, 97, 166, 171, 134, 15, 220, 233, 62, 80, 212, 136, 176, 2, 177, 70, 29, 250, 1, 113, 87, 92, 242, 186, 52 }, new byte[] { 143, 157, 160, 16, 252, 186, 33, 77, 220, 198, 26, 112, 84, 95, 141, 44, 75, 3, 83, 228, 142, 46, 161, 2, 220, 105, 15, 81, 216, 181, 150, 77, 142, 201, 189, 198, 51, 79, 64, 151, 15, 235, 61, 160, 65, 97, 88, 88, 24, 156, 77, 177, 36, 185, 173, 175, 189, 210, 24, 244, 177, 119, 241, 241, 149, 117, 58, 33, 57, 1, 56, 119, 217, 243, 238, 1, 212, 202, 136, 168, 190, 4, 47, 65, 93, 45, 209, 159, 48, 29, 236, 150, 78, 13, 98, 121, 220, 227, 129, 177, 181, 111, 39, 157, 215, 165, 203, 45, 79, 136, 53, 122, 140, 69, 23, 224, 246, 248, 175, 241, 126, 129, 51, 229, 104, 174, 192, 238 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Lessons");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 179, 178, 18, 125, 22, 136, 114, 20, 56, 51, 214, 88, 213, 196, 200, 128, 0, 134, 80, 139, 84, 27, 175, 231, 44, 244, 200, 7, 170, 19, 224, 114, 83, 37, 223, 64, 232, 117, 223, 63, 10, 235, 73, 202, 103, 163, 132, 111, 4, 61, 162, 28, 98, 66, 74, 91, 124, 31, 94, 106, 241, 105, 2, 247 }, new byte[] { 208, 164, 174, 190, 27, 101, 11, 69, 250, 65, 235, 166, 115, 240, 108, 15, 214, 26, 107, 200, 44, 34, 116, 196, 54, 103, 215, 194, 88, 91, 25, 4, 17, 181, 114, 136, 67, 102, 24, 88, 206, 176, 124, 122, 191, 219, 97, 60, 90, 81, 216, 43, 196, 176, 217, 184, 87, 21, 21, 166, 60, 70, 116, 190, 85, 200, 207, 220, 7, 89, 122, 255, 201, 230, 3, 7, 32, 2, 144, 145, 201, 9, 18, 58, 99, 91, 248, 245, 245, 213, 132, 35, 103, 13, 50, 128, 241, 185, 152, 91, 212, 6, 251, 138, 59, 131, 46, 187, 104, 99, 232, 54, 15, 101, 106, 109, 186, 54, 204, 139, 9, 57, 82, 86, 233, 132, 201, 28 } });
        }
    }
}
