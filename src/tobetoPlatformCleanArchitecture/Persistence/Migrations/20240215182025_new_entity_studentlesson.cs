using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class new_entity_studentlesson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentLessons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    LessonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentLessons_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentLessons_Students_StudentId",
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
                values: new object[] { new byte[] { 120, 94, 156, 5, 140, 120, 222, 221, 77, 57, 86, 119, 177, 213, 237, 88, 154, 145, 214, 0, 199, 155, 163, 241, 118, 59, 195, 209, 40, 115, 134, 124, 121, 163, 78, 87, 10, 177, 228, 38, 20, 160, 232, 164, 178, 197, 102, 99, 36, 114, 8, 151, 181, 112, 7, 169, 133, 141, 235, 166, 146, 138, 164, 48 }, new byte[] { 21, 216, 200, 34, 141, 191, 126, 119, 188, 209, 94, 52, 210, 186, 177, 226, 158, 17, 238, 49, 133, 116, 127, 150, 132, 137, 92, 28, 224, 185, 55, 205, 79, 84, 197, 97, 129, 186, 224, 142, 162, 58, 98, 251, 45, 140, 149, 139, 60, 132, 141, 31, 62, 110, 71, 159, 172, 133, 236, 207, 47, 111, 193, 17, 184, 221, 4, 136, 240, 64, 84, 8, 32, 76, 236, 118, 58, 219, 227, 166, 118, 49, 212, 51, 210, 249, 138, 93, 38, 39, 158, 27, 114, 72, 222, 185, 42, 246, 229, 76, 168, 116, 53, 146, 2, 246, 173, 136, 32, 77, 118, 244, 103, 178, 63, 202, 230, 125, 10, 149, 42, 32, 4, 187, 50, 86, 46, 116 } });

            migrationBuilder.CreateIndex(
                name: "IX_StudentLessons_LessonId",
                table: "StudentLessons",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLessons_StudentId",
                table: "StudentLessons",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentLessons");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 128, 62, 232, 223, 22, 130, 115, 219, 47, 155, 194, 119, 88, 92, 196, 75, 112, 121, 192, 18, 165, 204, 116, 235, 239, 49, 18, 88, 45, 233, 131, 134, 204, 11, 227, 80, 226, 118, 34, 162, 130, 92, 166, 83, 205, 64, 0, 246, 152, 25, 116, 106, 150, 250, 240, 39, 27, 89, 71, 75, 15, 85, 204, 255 }, new byte[] { 67, 186, 20, 103, 75, 246, 113, 145, 13, 147, 51, 89, 66, 20, 19, 23, 240, 126, 136, 10, 81, 178, 17, 244, 54, 167, 124, 102, 251, 147, 158, 199, 94, 99, 245, 146, 127, 19, 144, 63, 231, 182, 150, 155, 205, 113, 224, 242, 253, 221, 92, 238, 140, 211, 156, 164, 33, 71, 81, 238, 121, 64, 195, 132, 197, 36, 35, 76, 238, 72, 227, 109, 76, 173, 109, 50, 232, 141, 127, 102, 17, 75, 151, 184, 38, 51, 215, 162, 155, 107, 71, 10, 79, 78, 60, 241, 62, 131, 237, 61, 50, 38, 214, 92, 41, 66, 50, 189, 78, 119, 174, 151, 219, 53, 82, 137, 45, 53, 107, 119, 218, 215, 139, 139, 97, 221, 42, 66 } });
        }
    }
}
