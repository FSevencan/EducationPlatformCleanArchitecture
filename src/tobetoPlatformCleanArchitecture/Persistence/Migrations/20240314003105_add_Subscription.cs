using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_Subscription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClassRoomTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_ClassRoomTypes_ClassRoomTypeId",
                        column: x => x.ClassRoomTypeId,
                        principalTable: "ClassRoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 215, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Contacts.Admin", null },
                    { 216, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Contacts.Read", null },
                    { 217, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Contacts.Write", null },
                    { 218, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Contacts.Add", null },
                    { 219, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Contacts.Update", null },
                    { 220, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Contacts.Delete", null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 248, 16, 203, 97, 215, 242, 170, 195, 171, 107, 217, 43, 233, 174, 235, 93, 192, 109, 119, 191, 166, 34, 109, 219, 202, 135, 121, 26, 157, 115, 210, 66, 68, 90, 87, 86, 217, 154, 193, 126, 3, 143, 200, 197, 230, 25, 26, 180, 189, 125, 7, 29, 73, 68, 190, 231, 30, 185, 178, 179, 73, 230, 203, 194 }, new byte[] { 192, 199, 253, 143, 114, 62, 12, 106, 120, 21, 91, 247, 216, 78, 134, 137, 136, 89, 193, 38, 199, 222, 145, 213, 252, 42, 7, 89, 10, 172, 93, 228, 174, 59, 191, 4, 205, 216, 92, 39, 204, 54, 178, 86, 107, 201, 175, 93, 68, 149, 191, 134, 102, 40, 88, 246, 24, 41, 22, 57, 128, 110, 103, 72, 215, 198, 168, 92, 122, 215, 68, 175, 227, 249, 27, 63, 88, 232, 132, 29, 73, 68, 238, 190, 93, 20, 0, 210, 66, 54, 99, 215, 252, 234, 206, 196, 247, 240, 22, 70, 18, 17, 228, 145, 42, 64, 25, 26, 184, 237, 127, 241, 240, 197, 140, 78, 203, 100, 193, 99, 117, 95, 226, 86, 104, 103, 114, 163 } });

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_ClassRoomTypeId",
                table: "Subscriptions",
                column: "ClassRoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_UserId",
                table: "Subscriptions",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscriptions");

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 230, 82, 114, 156, 230, 235, 236, 233, 56, 165, 131, 215, 38, 172, 15, 252, 134, 48, 230, 54, 80, 93, 120, 255, 197, 99, 146, 172, 204, 225, 53, 136, 150, 249, 7, 102, 41, 78, 89, 82, 30, 103, 119, 16, 20, 23, 240, 39, 185, 170, 62, 191, 134, 10, 178, 170, 29, 213, 222, 229, 127, 141, 193, 10 }, new byte[] { 107, 228, 130, 91, 130, 150, 126, 7, 31, 152, 86, 26, 114, 187, 137, 115, 128, 26, 16, 189, 95, 191, 35, 19, 150, 87, 238, 161, 75, 65, 218, 146, 177, 237, 152, 230, 88, 103, 72, 38, 70, 52, 161, 46, 128, 138, 97, 215, 124, 27, 161, 134, 160, 4, 24, 81, 12, 240, 122, 75, 91, 102, 89, 42, 216, 220, 236, 34, 101, 5, 48, 16, 183, 197, 145, 184, 79, 206, 216, 246, 131, 87, 94, 127, 54, 219, 63, 215, 143, 82, 105, 165, 235, 13, 162, 47, 59, 201, 157, 182, 111, 215, 87, 145, 82, 180, 11, 95, 178, 221, 46, 55, 168, 57, 223, 128, 67, 131, 74, 23, 65, 104, 96, 163, 22, 207, 51, 115 } });
        }
    }
}
