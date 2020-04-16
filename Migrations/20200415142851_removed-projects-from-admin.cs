using Microsoft.EntityFrameworkCore.Migrations;

namespace ICE_API.Migrations
{
    public partial class removedprojectsfromadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Admin_AdminID",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_AdminID",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "AdminID",
                table: "Project");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminID",
                table: "Project",
                type: "int",
                nullable: true);

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
    }
}
