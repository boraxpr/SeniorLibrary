using Microsoft.EntityFrameworkCore.Migrations;

namespace SeniorLibrary.Migrations
{
    public partial class FixSeniorLibraryContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubmittorEmail",
                table: "Entrying",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubmittorEmail",
                table: "Entrying");
        }
    }
}
