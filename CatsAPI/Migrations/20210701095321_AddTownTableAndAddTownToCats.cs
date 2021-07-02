using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cats.API.Migrations
{
    public partial class AddTownTableAndAddTownToCats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TownId",
                table: "Cats",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Towns",
                columns: table => new
                {
                    TownId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.TownId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cats_TownId",
                table: "Cats",
                column: "TownId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cats_Towns_TownId",
                table: "Cats",
                column: "TownId",
                principalTable: "Towns",
                principalColumn: "TownId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cats_Towns_TownId",
                table: "Cats");

            migrationBuilder.DropTable(
                name: "Towns");

            migrationBuilder.DropIndex(
                name: "IX_Cats_TownId",
                table: "Cats");

            migrationBuilder.DropColumn(
                name: "TownId",
                table: "Cats");
        }
    }
}
