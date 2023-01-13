using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class degisiklik : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Admins_userTypeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_userTypeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "userTypeId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "adminPassword",
                table: "Admins",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "adminProfilPhoto",
                table: "Admins",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "adminPassword",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "adminProfilPhoto",
                table: "Admins");

            migrationBuilder.AddColumn<int>(
                name: "userTypeId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_userTypeId",
                table: "Users",
                column: "userTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Admins_userTypeId",
                table: "Users",
                column: "userTypeId",
                principalTable: "Admins",
                principalColumn: "adminId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
