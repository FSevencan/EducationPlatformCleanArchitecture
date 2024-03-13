using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_contact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 230, 82, 114, 156, 230, 235, 236, 233, 56, 165, 131, 215, 38, 172, 15, 252, 134, 48, 230, 54, 80, 93, 120, 255, 197, 99, 146, 172, 204, 225, 53, 136, 150, 249, 7, 102, 41, 78, 89, 82, 30, 103, 119, 16, 20, 23, 240, 39, 185, 170, 62, 191, 134, 10, 178, 170, 29, 213, 222, 229, 127, 141, 193, 10 }, new byte[] { 107, 228, 130, 91, 130, 150, 126, 7, 31, 152, 86, 26, 114, 187, 137, 115, 128, 26, 16, 189, 95, 191, 35, 19, 150, 87, 238, 161, 75, 65, 218, 146, 177, 237, 152, 230, 88, 103, 72, 38, 70, 52, 161, 46, 128, 138, 97, 215, 124, 27, 161, 134, 160, 4, 24, 81, 12, 240, 122, 75, 91, 102, 89, 42, 216, 220, 236, 34, 101, 5, 48, 16, 183, 197, 145, 184, 79, 206, 216, 246, 131, 87, 94, 127, 54, 219, 63, 215, 143, 82, 105, 165, 235, 13, 162, 47, 59, 201, 157, 182, 111, 215, 87, 145, 82, 180, 11, 95, 178, 221, 46, 55, 168, 57, 223, 128, 67, 131, 74, 23, 65, 104, 96, 163, 22, 207, 51, 115 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 243, 136, 109, 109, 230, 221, 17, 193, 132, 11, 123, 41, 185, 17, 210, 43, 29, 62, 113, 104, 32, 62, 211, 144, 80, 14, 130, 128, 30, 77, 30, 204, 18, 250, 183, 88, 40, 100, 56, 179, 179, 188, 137, 89, 77, 160, 208, 229, 214, 153, 71, 82, 214, 23, 142, 127, 65, 100, 116, 169, 71, 48, 197, 243 }, new byte[] { 198, 179, 4, 239, 73, 51, 78, 119, 7, 147, 90, 191, 69, 61, 135, 98, 216, 212, 28, 50, 255, 162, 73, 191, 5, 250, 12, 164, 130, 218, 38, 135, 224, 17, 31, 49, 253, 176, 150, 208, 78, 43, 115, 167, 182, 237, 244, 80, 46, 62, 245, 86, 27, 141, 219, 98, 101, 186, 218, 118, 164, 140, 197, 198, 161, 240, 128, 230, 235, 29, 111, 14, 129, 184, 201, 94, 90, 86, 67, 224, 56, 158, 4, 63, 200, 225, 132, 142, 92, 178, 51, 144, 53, 33, 126, 134, 136, 129, 64, 48, 92, 22, 202, 53, 243, 0, 81, 27, 237, 113, 185, 212, 82, 202, 212, 15, 200, 176, 81, 240, 22, 163, 139, 131, 43, 107, 249, 253 } });
        }
    }
}
