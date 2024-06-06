using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LifestyleChecker.DataLayer.Migrations
{
    public partial class CreateTableAndPopulate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    Score_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<int>(type: "int", nullable: false),
                    To = table.Column<int>(type: "int", nullable: true),
                    Q1 = table.Column<int>(type: "int", nullable: false),
                    Q2 = table.Column<int>(type: "int", nullable: false),
                    Q3 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.Score_ID);
                });

            migrationBuilder.InsertData(
                table: "Scores",
                columns: new[] { "Score_ID", "From", "Q1", "Q2", "Q3", "To" },
                values: new object[,]
                {
                    { 1, 16, 1, 2, 1, 21 },
                    { 2, 22, 2, 2, 3, 40 },
                    { 3, 41, 3, 2, 2, 65 },
                    { 4, 64, 3, 3, 1, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Scores");
        }
    }
}
