using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveIsActiveFromLikeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Likes");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 166, 117, 147, 38, 150, 242, 170, 224, 136, 151, 91, 32, 252, 62, 174, 219, 179, 48, 205, 211, 249, 157, 137, 75, 76, 69, 168, 87, 41, 84, 243, 98, 206, 108, 129, 163, 220, 192, 26, 232, 138, 151, 176, 251, 165, 218, 110, 182, 41, 217, 103, 11, 194, 159, 88, 12, 226, 196, 224, 64, 197, 22, 84, 82 }, new byte[] { 169, 44, 60, 135, 111, 213, 73, 75, 67, 214, 59, 58, 193, 215, 84, 177, 32, 85, 83, 69, 73, 239, 92, 246, 124, 88, 243, 9, 185, 91, 10, 76, 223, 246, 192, 80, 174, 207, 234, 183, 129, 22, 17, 56, 144, 67, 192, 253, 115, 133, 145, 216, 178, 122, 139, 166, 147, 38, 207, 218, 226, 133, 76, 229, 208, 203, 52, 231, 63, 66, 226, 73, 242, 179, 186, 143, 48, 121, 202, 230, 33, 138, 97, 252, 67, 53, 234, 78, 15, 167, 213, 81, 135, 43, 39, 142, 146, 146, 68, 18, 113, 92, 228, 201, 138, 24, 216, 223, 42, 53, 236, 189, 61, 171, 83, 109, 229, 41, 178, 161, 214, 51, 135, 217, 119, 240, 42, 152 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Likes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 169, 145, 177, 16, 192, 185, 144, 27, 110, 8, 209, 160, 203, 149, 65, 83, 253, 13, 159, 95, 168, 213, 177, 130, 39, 147, 147, 173, 92, 201, 246, 158, 212, 61, 47, 46, 228, 23, 183, 111, 138, 185, 201, 115, 120, 244, 16, 168, 137, 180, 7, 249, 62, 119, 252, 59, 75, 46, 15, 221, 151, 10, 191, 44 }, new byte[] { 173, 11, 30, 197, 178, 129, 119, 4, 35, 144, 36, 87, 189, 18, 32, 100, 134, 241, 13, 200, 203, 107, 79, 249, 61, 9, 56, 4, 205, 229, 36, 166, 25, 62, 84, 163, 77, 209, 151, 132, 23, 184, 105, 33, 127, 189, 171, 171, 84, 109, 224, 170, 73, 88, 152, 182, 196, 111, 45, 230, 155, 27, 132, 98, 109, 240, 121, 107, 62, 94, 208, 230, 127, 34, 202, 67, 5, 94, 197, 88, 116, 59, 128, 88, 235, 3, 206, 203, 205, 44, 235, 167, 223, 192, 212, 249, 224, 41, 88, 245, 138, 23, 89, 99, 179, 0, 41, 193, 121, 48, 253, 153, 181, 122, 214, 252, 221, 97, 181, 149, 81, 237, 81, 14, 193, 80, 117, 71 } });
        }
    }
}
