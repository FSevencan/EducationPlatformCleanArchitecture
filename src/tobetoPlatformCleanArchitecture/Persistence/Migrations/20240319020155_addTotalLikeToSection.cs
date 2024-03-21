using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addTotalLikeToSection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalLike",
                table: "Sections",
                type: "int",
                nullable: false,
                defaultValue: 0);

           

           
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 169, 145, 177, 16, 192, 185, 144, 27, 110, 8, 209, 160, 203, 149, 65, 83, 253, 13, 159, 95, 168, 213, 177, 130, 39, 147, 147, 173, 92, 201, 246, 158, 212, 61, 47, 46, 228, 23, 183, 111, 138, 185, 201, 115, 120, 244, 16, 168, 137, 180, 7, 249, 62, 119, 252, 59, 75, 46, 15, 221, 151, 10, 191, 44 }, new byte[] { 173, 11, 30, 197, 178, 129, 119, 4, 35, 144, 36, 87, 189, 18, 32, 100, 134, 241, 13, 200, 203, 107, 79, 249, 61, 9, 56, 4, 205, 229, 36, 166, 25, 62, 84, 163, 77, 209, 151, 132, 23, 184, 105, 33, 127, 189, 171, 171, 84, 109, 224, 170, 73, 88, 152, 182, 196, 111, 45, 230, 155, 27, 132, 98, 109, 240, 121, 107, 62, 94, 208, 230, 127, 34, 202, 67, 5, 94, 197, 88, 116, 59, 128, 88, 235, 3, 206, 203, 205, 44, 235, 167, 223, 192, 212, 249, 224, 41, 88, 245, 138, 23, 89, 99, 179, 0, 41, 193, 121, 48, 253, 153, 181, 122, 214, 252, 221, 97, 181, 149, 81, 237, 81, 14, 193, 80, 117, 71 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropColumn(
                name: "TotalLike",
                table: "Sections");

           

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 230, 82, 114, 156, 230, 235, 236, 233, 56, 165, 131, 215, 38, 172, 15, 252, 134, 48, 230, 54, 80, 93, 120, 255, 197, 99, 146, 172, 204, 225, 53, 136, 150, 249, 7, 102, 41, 78, 89, 82, 30, 103, 119, 16, 20, 23, 240, 39, 185, 170, 62, 191, 134, 10, 178, 170, 29, 213, 222, 229, 127, 141, 193, 10 }, new byte[] { 107, 228, 130, 91, 130, 150, 126, 7, 31, 152, 86, 26, 114, 187, 137, 115, 128, 26, 16, 189, 95, 191, 35, 19, 150, 87, 238, 161, 75, 65, 218, 146, 177, 237, 152, 230, 88, 103, 72, 38, 70, 52, 161, 46, 128, 138, 97, 215, 124, 27, 161, 134, 160, 4, 24, 81, 12, 240, 122, 75, 91, 102, 89, 42, 216, 220, 236, 34, 101, 5, 48, 16, 183, 197, 145, 184, 79, 206, 216, 246, 131, 87, 94, 127, 54, 219, 63, 215, 143, 82, 105, 165, 235, 13, 162, 47, 59, 201, 157, 182, 111, 215, 87, 145, 82, 180, 11, 95, 178, 221, 46, 55, 168, 57, 223, 128, 67, 131, 74, 23, 65, 104, 96, 163, 22, 207, 51, 115 } });
        }
    }
}
