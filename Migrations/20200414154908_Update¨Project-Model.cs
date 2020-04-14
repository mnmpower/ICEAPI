using Microsoft.EntityFrameworkCore.Migrations;

namespace ICE_API.Migrations
{
    public partial class UpdateProjectModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmbeddedURL",
                table: "Project");

            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "datum",
                table: "Project",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Img",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "datum",
                table: "Project");

            migrationBuilder.AddColumn<string>(
                name: "EmbeddedURL",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
