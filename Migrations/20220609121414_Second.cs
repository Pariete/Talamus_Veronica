using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Talamus_Veronica.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identifier",
                table: "PartOfStories");

            migrationBuilder.AddColumn<bool>(
                name: "SetSubsequent",
                table: "PartOfStories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SetSubsequent",
                table: "PartOfStories");

            migrationBuilder.AddColumn<Guid>(
                name: "Identifier",
                table: "PartOfStories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
