using Microsoft.EntityFrameworkCore.Migrations;

namespace MigrationEx.Migrations
{
    public partial class V3RenameTagId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TagIdNew",
                table: "Tag",
                newName: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "Tag",
                newName: "TagIdNew");
        }
    }
}
