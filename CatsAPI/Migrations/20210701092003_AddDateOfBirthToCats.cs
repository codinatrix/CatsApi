using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cats.API.Migrations
{
    public partial class AddDateOfBirthToCats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Cats",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Cats");
        }
    }
}
