using Microsoft.EntityFrameworkCore.Migrations;

namespace mission_six_movie_db.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "responses",
                columns: table => new
                {
                    MovieFormId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Category = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Director = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Edited = table.Column<bool>(nullable: false),
                    LentTo = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_responses", x => x.MovieFormId);
                });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "MovieFormId", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 1, "Disney", "Mark Dindal", false, null, "World's best movie", "G", "Emperor's New Groove", 2000 });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "MovieFormId", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 2, "Comedy", "Jonathan Lynn", false, null, null, "R", "My Cousin Vinny", 1992 });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "MovieFormId", "Category", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 3, "Fantasy", "Hayao Miyazaki", false, null, null, "G", "My Neighbor Totoro", 1988 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "responses");
        }
    }
}
