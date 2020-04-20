using Microsoft.EntityFrameworkCore.Migrations;

namespace ICE_API.Migrations
{
    public partial class Addedstatuscategoryinitiatifupdatepersonproject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Show",
                table: "Project",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Person",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "Initiatif",
                columns: table => new
                {
                    InitiatifID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    StartDate = table.Column<string>(nullable: true),
                    About = table.Column<string>(nullable: true),
                    TaskDescription = table.Column<string>(nullable: true),
                    Confirmed = table.Column<bool>(nullable: false),
                    location = table.Column<string>(nullable: true),
                    PersonID = table.Column<int>(nullable: false),
                    StatusID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Initiatif", x => x.InitiatifID);
                    table.ForeignKey(
                        name: "FK_Initiatif_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Initiatif_Person_PersonID",
                        column: x => x.PersonID,
                        principalTable: "Person",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Initiatif_Status_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Status",
                        principalColumn: "StatusID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_CategoryID",
                table: "Project",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Initiatif_CategoryID",
                table: "Initiatif",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Initiatif_PersonID",
                table: "Initiatif",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_Initiatif_StatusID",
                table: "Initiatif",
                column: "StatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Category_CategoryID",
                table: "Project",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Category_CategoryID",
                table: "Project");

            migrationBuilder.DropTable(
                name: "Initiatif");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Project_CategoryID",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Show",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Person");
        }
    }
}
