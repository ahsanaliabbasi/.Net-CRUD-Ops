using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalks.API.Migrations.NZWalksAuthDB
{
    /// <inheritdoc />
    public partial class DBRolesUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d30ca45-bb70-4599-ad44-6d376a6e14f4",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Witer", "WRITER" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f8029dc-5c18-4c91-b774-38f0305c608a",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Reader", "READER" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d30ca45-bb70-4599-ad44-6d376a6e14f4",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "5d30ca45-bb70-4599-ad44-6d376a6e14f4", "5D30CA45-BB70-4599-AD44-6D376A6E14F4" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7f8029dc-5c18-4c91-b774-38f0305c608a",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "7f8029dc-5c18-4c91-b774-38f0305c608a", "7F8029DC-5C18-4C91-B774-38F0305C608A" });
        }
    }
}
