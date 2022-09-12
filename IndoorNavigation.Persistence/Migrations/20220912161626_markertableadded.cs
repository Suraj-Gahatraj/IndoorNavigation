using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndoorNavigation.Persistence.Migrations
{
    public partial class markertableadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_siteMarkerImages",
                table: "siteMarkerImages");

            migrationBuilder.RenameTable(
                name: "siteMarkerImages",
                newName: "SiteMarkerImages");

            migrationBuilder.RenameColumn(
                name: "MapMarkerId",
                table: "SiteMarkerImages",
                newName: "MarkerId");

            migrationBuilder.AddColumn<decimal>(
                name: "X",
                table: "SiteMarkerImages",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Y",
                table: "SiteMarkerImages",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Z",
                table: "SiteMarkerImages",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SiteMarkerImages",
                table: "SiteMarkerImages",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Markers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    X_Pos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Y_Pos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Z_Pos = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Markers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SiteMarkerImages",
                table: "SiteMarkerImages");

            migrationBuilder.DropColumn(
                name: "X",
                table: "SiteMarkerImages");

            migrationBuilder.DropColumn(
                name: "Y",
                table: "SiteMarkerImages");

            migrationBuilder.DropColumn(
                name: "Z",
                table: "SiteMarkerImages");

            migrationBuilder.RenameTable(
                name: "SiteMarkerImages",
                newName: "siteMarkerImages");

            migrationBuilder.RenameColumn(
                name: "MarkerId",
                table: "siteMarkerImages",
                newName: "MapMarkerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_siteMarkerImages",
                table: "siteMarkerImages",
                column: "Id");
        }
    }
}
