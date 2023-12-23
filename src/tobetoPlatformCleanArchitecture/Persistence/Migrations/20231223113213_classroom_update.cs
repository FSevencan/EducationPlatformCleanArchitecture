using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class classroom_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentClassRooms_ClassRooms_ClassRoomId1",
                table: "StudentClassRooms");

            migrationBuilder.DropIndex(
                name: "IX_StudentClassRooms_ClassRoomId1",
                table: "StudentClassRooms");

            migrationBuilder.DropColumn(
                name: "ClassRoomId1",
                table: "StudentClassRooms");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClassRoomId",
                table: "StudentClassRooms",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 172, 148, 255, 52, 149, 122, 21, 43, 85, 87, 76, 22, 119, 49, 39, 94, 156, 239, 25, 143, 176, 108, 201, 66, 91, 121, 23, 198, 255, 105, 156, 227, 243, 165, 150, 218, 70, 210, 193, 77, 192, 100, 191, 128, 118, 240, 106, 245, 47, 95, 204, 231, 123, 230, 92, 222, 107, 70, 133, 232, 180, 161, 72, 111 }, new byte[] { 7, 240, 74, 208, 67, 164, 234, 120, 245, 149, 52, 191, 251, 207, 46, 170, 202, 202, 23, 184, 253, 24, 225, 51, 124, 23, 67, 35, 100, 94, 212, 0, 128, 189, 214, 212, 50, 12, 4, 241, 122, 24, 181, 149, 38, 60, 149, 72, 56, 161, 58, 62, 123, 133, 67, 198, 234, 127, 59, 169, 80, 8, 8, 207, 149, 124, 230, 239, 34, 74, 160, 50, 255, 159, 66, 73, 143, 31, 58, 63, 36, 16, 251, 147, 16, 32, 128, 150, 18, 79, 45, 108, 217, 1, 92, 243, 45, 245, 173, 84, 143, 56, 26, 225, 213, 115, 217, 185, 145, 240, 175, 6, 240, 144, 22, 50, 223, 187, 106, 55, 176, 230, 238, 153, 150, 37, 101, 97 } });

            migrationBuilder.CreateIndex(
                name: "IX_StudentClassRooms_ClassRoomId",
                table: "StudentClassRooms",
                column: "ClassRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClassRooms_ClassRooms_ClassRoomId",
                table: "StudentClassRooms",
                column: "ClassRoomId",
                principalTable: "ClassRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentClassRooms_ClassRooms_ClassRoomId",
                table: "StudentClassRooms");

            migrationBuilder.DropIndex(
                name: "IX_StudentClassRooms_ClassRoomId",
                table: "StudentClassRooms");

            migrationBuilder.AlterColumn<int>(
                name: "ClassRoomId",
                table: "StudentClassRooms",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "ClassRoomId1",
                table: "StudentClassRooms",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 16, 182, 166, 171, 4, 204, 180, 27, 252, 48, 21, 255, 181, 243, 210, 84, 97, 90, 231, 77, 105, 55, 107, 191, 25, 157, 20, 67, 235, 85, 33, 177, 47, 139, 20, 225, 104, 133, 207, 226, 63, 80, 50, 120, 154, 254, 185, 118, 255, 198, 81, 202, 138, 115, 179, 158, 233, 100, 79, 18, 31, 105, 187, 243 }, new byte[] { 91, 250, 37, 15, 110, 26, 55, 23, 151, 237, 128, 47, 245, 37, 189, 119, 189, 178, 6, 166, 53, 117, 211, 27, 194, 52, 190, 92, 253, 165, 70, 107, 230, 44, 227, 125, 207, 44, 197, 178, 181, 30, 22, 209, 136, 196, 92, 69, 178, 214, 58, 44, 236, 13, 98, 4, 140, 178, 24, 36, 201, 218, 17, 95, 113, 60, 165, 168, 250, 9, 1, 53, 206, 141, 112, 19, 34, 54, 149, 231, 6, 67, 9, 103, 109, 64, 110, 181, 182, 138, 25, 152, 70, 0, 30, 162, 145, 186, 123, 221, 8, 241, 33, 213, 37, 112, 244, 99, 91, 204, 251, 41, 39, 141, 239, 210, 196, 74, 105, 126, 57, 247, 176, 6, 72, 69, 211, 105 } });

            migrationBuilder.CreateIndex(
                name: "IX_StudentClassRooms_ClassRoomId1",
                table: "StudentClassRooms",
                column: "ClassRoomId1");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClassRooms_ClassRooms_ClassRoomId1",
                table: "StudentClassRooms",
                column: "ClassRoomId1",
                principalTable: "ClassRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
