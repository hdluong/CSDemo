using Microsoft.EntityFrameworkCore.Migrations;

namespace MigrationEx.Migrations
{
    public partial class V4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleTag",
                columns: table => new
                {
                    ArticleTagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTag", x => x.ArticleTagId);
                    table.ForeignKey(
                        name: "FK_ArticleTag_article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "article",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTag_ArticleId_TagId",
                table: "ArticleTag",
                columns: new[] { "ArticleId", "TagId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTag_TagId",
                table: "ArticleTag",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleTag");
        }
    }
}
