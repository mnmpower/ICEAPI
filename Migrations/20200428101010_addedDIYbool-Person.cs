using Microsoft.EntityFrameworkCore.Migrations;

namespace ICE_API.Migrations
{
    public partial class addedDIYboolPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DIY",
                table: "Person",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DIY",
                table: "Person");
        }
    }
}
