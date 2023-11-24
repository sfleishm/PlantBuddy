using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantBuddy.Migrations
{
    public partial class wateredon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "WateredOn",
                table: "WaterHistories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WateredOn",
                table: "WaterHistories");
        }
    }
}
