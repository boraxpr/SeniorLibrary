using Microsoft.EntityFrameworkCore.Migrations;

namespace SeniorLibrary.Migrations
{
    public partial class fixEntrying : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Entrying");

            migrationBuilder.AddColumn<string>(
                name: "BookAdvisor",
                table: "Entrying",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookAdvisor",
                table: "Entrying");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Entrying",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
