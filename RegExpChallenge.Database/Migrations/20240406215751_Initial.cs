using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RegExpChallenge.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Challenges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Examples",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    IsPublic = table.Column<bool>(type: "INTEGER", nullable: false),
                    ChallengeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examples", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Examples_Challenges_ChallengeId",
                        column: x => x.ChallengeId,
                        principalTable: "Challenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExampleMatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    Length = table.Column<int>(type: "INTEGER", nullable: false),
                    ExampleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExampleMatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExampleMatches_Examples_ExampleId",
                        column: x => x.ExampleId,
                        principalTable: "Examples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Challenges",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "Match all uppercase letters. If there are multiple uppercase letters after each other, match character sequences together.", "Uppercase letters" });

            migrationBuilder.InsertData(
                table: "Examples",
                columns: new[] { "Id", "ChallengeId", "IsPublic", "Text" },
                values: new object[,]
                {
                    { 1, 1, true, "THIS IS AN ALL UPPERCASE SENTENCE." },
                    { 2, 1, true, "This IS a SENTENCE with BOTH uppercase AND lowercase WORDS." },
                    { 3, 1, true, "this is a sentence with all lowercase." },
                    { 4, 1, true, "This sentence has only one uppercase letter." },
                    { 5, 1, true, "In This Sentence, Every Word Starts With Uppercase." }
                });

            migrationBuilder.InsertData(
                table: "ExampleMatches",
                columns: new[] { "Id", "ExampleId", "Index", "Length" },
                values: new object[,]
                {
                    { 1, 1, 0, 4 },
                    { 2, 1, 5, 2 },
                    { 3, 1, 8, 2 },
                    { 4, 1, 11, 3 },
                    { 5, 1, 15, 9 },
                    { 6, 1, 25, 8 },
                    { 7, 2, 0, 1 },
                    { 8, 2, 5, 2 },
                    { 9, 2, 10, 8 },
                    { 10, 2, 24, 4 },
                    { 11, 2, 39, 3 },
                    { 12, 2, 53, 5 },
                    { 13, 4, 0, 1 },
                    { 14, 5, 0, 1 },
                    { 15, 5, 3, 1 },
                    { 16, 5, 8, 1 },
                    { 17, 5, 18, 1 },
                    { 18, 5, 24, 1 },
                    { 19, 5, 29, 1 },
                    { 20, 5, 36, 1 },
                    { 21, 5, 41, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExampleMatches_ExampleId",
                table: "ExampleMatches",
                column: "ExampleId");

            migrationBuilder.CreateIndex(
                name: "IX_Examples_ChallengeId",
                table: "Examples",
                column: "ChallengeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExampleMatches");

            migrationBuilder.DropTable(
                name: "Examples");

            migrationBuilder.DropTable(
                name: "Challenges");
        }
    }
}
