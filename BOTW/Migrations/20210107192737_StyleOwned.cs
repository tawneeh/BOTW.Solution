using Microsoft.EntityFrameworkCore.Migrations;

namespace BOTW.Migrations
{
    public partial class StyleOwned : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Owned",
                table: "Styles",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Owned",
                table: "Styles");
        }
    }
}
