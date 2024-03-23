using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_Province_and_district : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "Students",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "Students",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 203, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Districts.Admin", null },
                    { 204, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Districts.Read", null },
                    { 205, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Districts.Write", null },
                    { 206, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Districts.Add", null },
                    { 207, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Districts.Update", null },
                    { 208, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Districts.Delete", null },
                    { 209, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Provinces.Admin", null },
                    { 210, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Provinces.Read", null },
                    { 211, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Provinces.Write", null },
                    { 212, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Provinces.Add", null },
                    { 213, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Provinces.Update", null },
                    { 214, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Provinces.Delete", null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 107, 218, 66, 221, 238, 187, 108, 184, 143, 5, 134, 139, 225, 75, 120, 117, 146, 232, 59, 51, 143, 124, 224, 232, 166, 12, 86, 222, 105, 144, 57, 127, 202, 1, 23, 153, 180, 23, 36, 51, 123, 51, 189, 177, 111, 130, 126, 94, 36, 160, 140, 23, 23, 215, 112, 223, 210, 197, 195, 225, 74, 83, 238, 25 }, new byte[] { 228, 245, 38, 252, 202, 218, 184, 134, 233, 43, 217, 128, 169, 112, 109, 231, 117, 211, 231, 20, 5, 245, 63, 63, 247, 150, 181, 159, 242, 107, 238, 226, 66, 76, 199, 114, 88, 186, 121, 208, 24, 70, 2, 156, 17, 77, 127, 20, 217, 98, 2, 247, 227, 155, 185, 254, 249, 62, 91, 216, 157, 93, 34, 55, 105, 89, 49, 122, 217, 173, 230, 9, 83, 93, 134, 103, 42, 82, 230, 158, 35, 161, 98, 134, 226, 169, 91, 11, 220, 22, 30, 159, 224, 230, 17, 68, 142, 9, 131, 215, 191, 176, 3, 156, 14, 89, 64, 153, 140, 42, 162, 65, 132, 79, 235, 9, 114, 67, 42, 239, 136, 101, 47, 103, 248, 163, 222, 132 } });

            migrationBuilder.CreateIndex(
                name: "IX_Students_DistrictId",
                table: "Students",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ProvinceId",
                table: "Students",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_ProvinceId",
                table: "Districts",
                column: "ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Districts_DistrictId",
                table: "Students",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Provinces_ProvinceId",
                table: "Students",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Districts_DistrictId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Provinces_ProvinceId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropIndex(
                name: "IX_Students_DistrictId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_ProvinceId",
                table: "Students");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "Students");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 85, 187, 163, 155, 213, 226, 188, 198, 43, 71, 120, 76, 43, 60, 69, 66, 72, 50, 189, 133, 147, 143, 70, 62, 94, 191, 94, 190, 30, 109, 240, 64, 21, 93, 140, 8, 152, 221, 9, 49, 194, 28, 189, 36, 226, 122, 243, 243, 215, 244, 237, 136, 115, 150, 24, 33, 160, 106, 4, 139, 161, 165, 85, 161 }, new byte[] { 85, 57, 41, 246, 176, 5, 121, 60, 5, 181, 232, 156, 10, 199, 189, 202, 197, 36, 29, 102, 126, 211, 191, 192, 213, 116, 15, 196, 234, 139, 26, 29, 73, 139, 244, 103, 188, 181, 254, 186, 237, 70, 100, 168, 59, 205, 77, 186, 103, 219, 27, 18, 145, 62, 176, 100, 80, 30, 12, 233, 98, 239, 146, 96, 56, 215, 14, 58, 243, 115, 241, 99, 117, 181, 45, 24, 85, 195, 147, 156, 74, 29, 137, 165, 195, 196, 212, 162, 154, 181, 213, 155, 182, 151, 122, 187, 59, 99, 36, 103, 83, 210, 116, 24, 33, 93, 176, 142, 150, 26, 75, 141, 145, 14, 39, 38, 25, 88, 34, 210, 104, 35, 133, 52, 112, 114, 166, 109 } });
        }
    }
}
