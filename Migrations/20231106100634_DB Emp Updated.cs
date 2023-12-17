using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class DBEmpUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "APM",
                table: "Employees",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_APM",
                table: "Employees",
                column: "APM");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_APM",
                table: "Employees",
                column: "APM",
                principalTable: "Employees",
                principalColumn: "QLID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_APM",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_APM",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "APM",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
