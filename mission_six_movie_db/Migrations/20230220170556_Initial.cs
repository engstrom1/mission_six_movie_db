using Microsoft.EntityFrameworkCore.Migrations;

namespace mission_six_movie_db.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CatId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.CatId);
                });

            migrationBuilder.CreateTable(
                name: "responses",
                columns: table => new
                {
                    MovieFormId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryId = table.Column<int>(nullable: false),
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
                    table.ForeignKey(
                        name: "FK_responses_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "CatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CatId", "CategoryName" },
                values: new object[] { 1, "Disney" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CatId", "CategoryName" },
                values: new object[] { 2, "Comedy" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CatId", "CategoryName" },
                values: new object[] { 3, "Fantasy" });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "MovieFormId", "CategoryId", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 1, 1, "Mark Dindal", false, null, "World's best movie", "G", "Emperor's New Groove", 2000 });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "MovieFormId", "CategoryId", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 2, 2, "Jonathan Lynn", false, null, null, "R", "My Cousin Vinny", 1992 });

            migrationBuilder.InsertData(
                table: "responses",
                columns: new[] { "MovieFormId", "CategoryId", "Director", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 3, 3, "Hayao Miyazaki", false, null, null, "G", "My Neighbor Totoro", 1988 });

            migrationBuilder.CreateIndex(
                name: "IX_responses_CategoryId",
                table: "responses",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "responses");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
