using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class DBUsersAllowNullsinAPM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_APM",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "APM",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_APM",
                table: "Users",
                column: "APM",
                principalTable: "Users",
                principalColumn: "QLID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_APM",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "APM",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_APM",
                table: "Users",
                column: "APM",
                principalTable: "Users",
                principalColumn: "QLID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
