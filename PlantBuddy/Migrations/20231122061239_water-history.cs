using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantBuddy.Migrations
{
    public partial class waterhistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResourceLink",
                table: "Plants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WaterHistories",
                columns: table => new
                {
                    WaterHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterHistories", x => x.WaterHistoryId);
                    table.ForeignKey(
                        name: "FK_WaterHistories_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "PlantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WaterHistories_PlantId",
                table: "WaterHistories",
                column: "PlantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WaterHistories");

            migrationBuilder.DropColumn(
                name: "ResourceLink",
                table: "Plants");
        }
    }
}
