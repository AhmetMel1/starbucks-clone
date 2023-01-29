using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class adminAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    adminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    adminFirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    adminLastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    adminPassword = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    adminType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    adminBirthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    adminImgUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    adminDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.adminId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");
        }
    }
}
