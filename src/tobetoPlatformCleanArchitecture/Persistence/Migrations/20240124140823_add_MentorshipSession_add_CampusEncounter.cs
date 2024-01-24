using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_MentorshipSession_add_CampusEncounter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CampusEncounters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampusEncounters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MentorshipSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Schedule = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeetingId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentorshipSessions", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 148, 227, 118, 163, 98, 108, 140, 17, 227, 246, 240, 5, 202, 228, 227, 175, 159, 185, 141, 195, 159, 64, 81, 37, 89, 216, 157, 229, 198, 169, 31, 49, 165, 212, 190, 174, 155, 169, 253, 194, 47, 156, 215, 167, 21, 19, 48, 250, 143, 50, 226, 170, 23, 250, 127, 170, 128, 80, 118, 218, 186, 236, 123, 204 }, new byte[] { 253, 58, 241, 201, 34, 17, 217, 175, 107, 141, 252, 213, 233, 74, 27, 123, 66, 152, 19, 139, 228, 178, 198, 200, 107, 23, 52, 126, 192, 82, 105, 219, 79, 31, 9, 11, 138, 219, 188, 168, 72, 3, 58, 31, 190, 255, 243, 227, 162, 88, 9, 181, 167, 199, 173, 166, 96, 77, 179, 208, 161, 54, 137, 163, 230, 159, 169, 114, 213, 23, 47, 50, 172, 123, 79, 63, 154, 54, 205, 44, 127, 171, 80, 41, 75, 182, 83, 240, 250, 0, 85, 78, 156, 137, 125, 175, 72, 29, 192, 213, 97, 113, 185, 37, 53, 149, 209, 74, 100, 105, 51, 180, 71, 231, 195, 151, 252, 215, 140, 224, 178, 11, 123, 5, 170, 113, 25, 107 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampusEncounters");

            migrationBuilder.DropTable(
                name: "MentorshipSessions");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 173, 180, 127, 69, 146, 65, 152, 60, 59, 210, 152, 83, 109, 42, 76, 248, 80, 194, 97, 10, 114, 146, 129, 18, 70, 248, 203, 24, 218, 174, 133, 31, 101, 41, 82, 142, 104, 119, 149, 213, 218, 47, 4, 198, 72, 105, 102, 137, 59, 98, 172, 50, 204, 34, 131, 125, 184, 206, 159, 171, 78, 145, 77, 62 }, new byte[] { 14, 35, 150, 219, 114, 222, 191, 60, 50, 104, 158, 188, 22, 4, 223, 180, 227, 49, 27, 132, 144, 209, 217, 241, 135, 43, 51, 75, 253, 91, 149, 208, 220, 129, 54, 115, 84, 231, 160, 27, 119, 208, 175, 124, 99, 61, 24, 6, 62, 134, 40, 161, 215, 126, 237, 255, 169, 129, 120, 188, 65, 240, 65, 186, 235, 68, 88, 206, 30, 196, 207, 210, 211, 7, 48, 126, 222, 213, 238, 114, 125, 47, 245, 255, 127, 204, 125, 164, 166, 175, 7, 63, 2, 238, 159, 102, 122, 158, 189, 42, 40, 108, 50, 254, 44, 196, 69, 72, 161, 236, 87, 0, 131, 46, 73, 113, 178, 82, 170, 236, 95, 66, 169, 145, 133, 147, 223, 77 } });
        }
    }
}
