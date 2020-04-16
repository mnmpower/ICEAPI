using Microsoft.EntityFrameworkCore.Migrations;

namespace ICE_API.Migrations
{
    public partial class Addedadminmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminID",
                table: "Project",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_AdminID",
                table: "Project",
                column: "AdminID");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Admin_AdminID",
                table: "Project",
                column: "AdminID",
                principalTable: "Admin",
                principalColumn: "AdminID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Admin_AdminID",
                table: "Project");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropIndex(
                name: "IX_Project_AdminID",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "AdminID",
                table: "Project");
        }
    }
}
