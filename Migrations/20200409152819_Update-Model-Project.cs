using Microsoft.EntityFrameworkCore.Migrations;

namespace ICE_API.Migrations
{
    public partial class UpdateModelProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IFrame",
                table: "Project");

            migrationBuilder.AddColumn<string>(
                name: "EmbeddedURL",
                table: "Project",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "PersonID", "Email", "FirstName", "LastName" },
                values: new object[] { 1, "m@m.be", "Maarten", "Michiels" });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "PersonID", "Email", "FirstName", "LastName" },
                values: new object[] { 2, "m@m.be", "Benji", "Virus" });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "ProjectID", "Description", "EmbeddedURL", "PersonID", "Title" },
                values: new object[] { 1, "First project", "https://www.youtube.com/embed/mNpQ3u56C3M", 1, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "PersonID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "ProjectID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Person",
                keyColumn: "PersonID",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "EmbeddedURL",
                table: "Project");

            migrationBuilder.AddColumn<string>(
                name: "IFrame",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
