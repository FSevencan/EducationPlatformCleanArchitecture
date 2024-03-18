using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class added_LikeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

           

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 56, 97, 140, 120, 127, 85, 244, 170, 152, 43, 199, 193, 228, 10, 43, 167, 150, 192, 26, 227, 10, 141, 193, 129, 71, 254, 150, 90, 15, 20, 9, 106, 186, 135, 230, 194, 94, 32, 187, 80, 215, 240, 221, 230, 139, 197, 217, 50, 233, 144, 204, 3, 81, 14, 93, 174, 116, 64, 96, 242, 34, 237, 160, 113 }, new byte[] { 88, 127, 162, 128, 230, 120, 119, 186, 99, 27, 104, 92, 158, 162, 173, 153, 232, 129, 229, 235, 111, 62, 80, 111, 225, 119, 17, 98, 236, 12, 69, 75, 149, 230, 239, 8, 66, 57, 203, 47, 224, 151, 61, 58, 17, 63, 19, 129, 30, 163, 93, 235, 40, 162, 167, 197, 103, 36, 60, 163, 129, 39, 68, 141, 64, 127, 78, 248, 160, 95, 200, 110, 236, 136, 22, 93, 114, 3, 6, 171, 41, 190, 232, 28, 190, 240, 233, 151, 152, 146, 81, 14, 40, 213, 4, 79, 67, 23, 241, 251, 229, 199, 139, 106, 21, 31, 249, 44, 128, 128, 124, 30, 138, 23, 234, 82, 136, 86, 215, 11, 236, 193, 77, 97, 168, 235, 104, 141 } });

            migrationBuilder.CreateIndex(
                name: "IX_Likes_SectionId",
                table: "Likes",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_StudentId",
                table: "Likes",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 199);

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
                values: new object[] { new byte[] { 230, 82, 114, 156, 230, 235, 236, 233, 56, 165, 131, 215, 38, 172, 15, 252, 134, 48, 230, 54, 80, 93, 120, 255, 197, 99, 146, 172, 204, 225, 53, 136, 150, 249, 7, 102, 41, 78, 89, 82, 30, 103, 119, 16, 20, 23, 240, 39, 185, 170, 62, 191, 134, 10, 178, 170, 29, 213, 222, 229, 127, 141, 193, 10 }, new byte[] { 107, 228, 130, 91, 130, 150, 126, 7, 31, 152, 86, 26, 114, 187, 137, 115, 128, 26, 16, 189, 95, 191, 35, 19, 150, 87, 238, 161, 75, 65, 218, 146, 177, 237, 152, 230, 88, 103, 72, 38, 70, 52, 161, 46, 128, 138, 97, 215, 124, 27, 161, 134, 160, 4, 24, 81, 12, 240, 122, 75, 91, 102, 89, 42, 216, 220, 236, 34, 101, 5, 48, 16, 183, 197, 145, 184, 79, 206, 216, 246, 131, 87, 94, 127, 54, 219, 63, 215, 143, 82, 105, 165, 235, 13, 162, 47, 59, 201, 157, 182, 111, 215, 87, 145, 82, 180, 11, 95, 178, 221, 46, 55, 168, 57, 223, 128, 67, 131, 74, 23, 65, 104, 96, 163, 22, 207, 51, 115 }, null, null });
        }
    }
}
