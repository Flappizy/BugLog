using Microsoft.EntityFrameworkCore.Migrations;

namespace Buglog.Migrations.AppDb
{
    public partial class StringDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortDateClosed",
                table: "Issues",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortDateCreated",
                table: "Issues",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortDateClosed",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "ShortDateCreated",
                table: "Issues");
        }
    }
}
