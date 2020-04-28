using Microsoft.EntityFrameworkCore.Migrations;

namespace ICE_API.Migrations
{
    public partial class addedTableDurationAgeCagegory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Project");

            migrationBuilder.AddColumn<int>(
                name: "AgeCategoryID",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DurationID",
                table: "Project",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AgeCategory",
                columns: table => new
                {
                    AgeCategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgeCategory", x => x.AgeCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Duration",
                columns: table => new
                {
                    DurationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duration", x => x.DurationID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_AgeCategoryID",
                table: "Project",
                column: "AgeCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Project_DurationID",
                table: "Project",
                column: "DurationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_AgeCategory_AgeCategoryID",
                table: "Project",
                column: "AgeCategoryID",
                principalTable: "AgeCategory",
                principalColumn: "AgeCategoryID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Duration_DurationID",
                table: "Project",
                column: "DurationID",
                principalTable: "Duration",
                principalColumn: "DurationID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_AgeCategory_AgeCategoryID",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Duration_DurationID",
                table: "Project");

            migrationBuilder.DropTable(
                name: "AgeCategory");

            migrationBuilder.DropTable(
                name: "Duration");

            migrationBuilder.DropIndex(
                name: "IX_Project_AgeCategoryID",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_DurationID",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "AgeCategoryID",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "DurationID",
                table: "Project");

            migrationBuilder.AddColumn<string>(
                name: "Age",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Time",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
