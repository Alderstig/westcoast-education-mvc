using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CourseNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseTitle = table.Column<string>(type: "TEXT", nullable: true),
                    CourseDesc = table.Column<string>(type: "TEXT", nullable: true),
                    CourseLength = table.Column<int>(type: "INTEGER", nullable: false),
                    CourseLevel = table.Column<string>(type: "TEXT", nullable: true),
                    Retired = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
