using Microsoft.EntityFrameworkCore.Migrations;

namespace ICE_API.Migrations
{
    public partial class addedTimeAgeProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Age",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Time",
                table: "Project",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Project");
        }
    }
}
