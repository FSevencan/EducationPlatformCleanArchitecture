using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_user_verificationToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<string>(
                name: "VerificationToken",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VerificationTokenExpires",
                table: "Users",
                type: "datetime2",
                nullable: true);

           

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt", "VerificationToken", "VerificationTokenExpires" },
                values: new object[] { new byte[] { 243, 136, 109, 109, 230, 221, 17, 193, 132, 11, 123, 41, 185, 17, 210, 43, 29, 62, 113, 104, 32, 62, 211, 144, 80, 14, 130, 128, 30, 77, 30, 204, 18, 250, 183, 88, 40, 100, 56, 179, 179, 188, 137, 89, 77, 160, 208, 229, 214, 153, 71, 82, 214, 23, 142, 127, 65, 100, 116, 169, 71, 48, 197, 243 }, new byte[] { 198, 179, 4, 239, 73, 51, 78, 119, 7, 147, 90, 191, 69, 61, 135, 98, 216, 212, 28, 50, 255, 162, 73, 191, 5, 250, 12, 164, 130, 218, 38, 135, 224, 17, 31, 49, 253, 176, 150, 208, 78, 43, 115, 167, 182, 237, 244, 80, 46, 62, 245, 86, 27, 141, 219, 98, 101, 186, 218, 118, 164, 140, 197, 198, 161, 240, 128, 230, 235, 29, 111, 14, 129, 184, 201, 94, 90, 86, 67, 224, 56, 158, 4, 63, 200, 225, 132, 142, 92, 178, 51, 144, 53, 33, 126, 134, 136, 129, 64, 48, 92, 22, 202, 53, 243, 0, 81, 27, 237, 113, 185, 212, 82, 202, 212, 15, 200, 176, 81, 240, 22, 163, 139, 131, 43, 107, 249, 253 }, null, null });

          

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            


            migrationBuilder.DropColumn(
                name: "VerificationToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VerificationTokenExpires",
                table: "Users");


            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 107, 218, 66, 221, 238, 187, 108, 184, 143, 5, 134, 139, 225, 75, 120, 117, 146, 232, 59, 51, 143, 124, 224, 232, 166, 12, 86, 222, 105, 144, 57, 127, 202, 1, 23, 153, 180, 23, 36, 51, 123, 51, 189, 177, 111, 130, 126, 94, 36, 160, 140, 23, 23, 215, 112, 223, 210, 197, 195, 225, 74, 83, 238, 25 }, new byte[] { 228, 245, 38, 252, 202, 218, 184, 134, 233, 43, 217, 128, 169, 112, 109, 231, 117, 211, 231, 20, 5, 245, 63, 63, 247, 150, 181, 159, 242, 107, 238, 226, 66, 76, 199, 114, 88, 186, 121, 208, 24, 70, 2, 156, 17, 77, 127, 20, 217, 98, 2, 247, 227, 155, 185, 254, 249, 62, 91, 216, 157, 93, 34, 55, 105, 89, 49, 122, 217, 173, 230, 9, 83, 93, 134, 103, 42, 82, 230, 158, 35, 161, 98, 134, 226, 169, 91, 11, 220, 22, 30, 159, 224, 230, 17, 68, 142, 9, 131, 215, 191, 176, 3, 156, 14, 89, 64, 153, 140, 42, 162, 65, 132, 79, 235, 9, 114, 67, 42, 239, 136, 101, 47, 103, 248, 163, 222, 132 } });

        }
    }
}
