using Microsoft.EntityFrameworkCore.Migrations;

namespace TestScaffold.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tendaydu",
                table: "Cungcap",
                newName: "FullName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Cungcap",
                newName: "Tendaydu");
        }
    }
}
