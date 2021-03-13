using Microsoft.EntityFrameworkCore.Migrations;

namespace SeniorLibrary.Migrations
{
    public partial class SeniorLibraryContextv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Entrying",
                newName: "SubmittedDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubmittedDate",
                table: "Entrying",
                newName: "Date");
        }
    }
}
