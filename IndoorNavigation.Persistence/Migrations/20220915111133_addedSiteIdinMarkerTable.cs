using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndoorNavigation.Persistence.Migrations
{
    public partial class addedSiteIdinMarkerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "MarkerId",
                table: "SiteMarkerImages",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "SiteId",
                table: "Markers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SiteMarkerImages_MarkerId",
                table: "SiteMarkerImages",
                column: "MarkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Markers_SiteId",
                table: "Markers",
                column: "SiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Markers_Sites_SiteId",
                table: "Markers",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SiteMarkerImages_Markers_MarkerId",
                table: "SiteMarkerImages",
                column: "MarkerId",
                principalTable: "Markers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Markers_Sites_SiteId",
                table: "Markers");

            migrationBuilder.DropForeignKey(
                name: "FK_SiteMarkerImages_Markers_MarkerId",
                table: "SiteMarkerImages");

            migrationBuilder.DropIndex(
                name: "IX_SiteMarkerImages_MarkerId",
                table: "SiteMarkerImages");

            migrationBuilder.DropIndex(
                name: "IX_Markers_SiteId",
                table: "Markers");

            migrationBuilder.DropColumn(
                name: "SiteId",
                table: "Markers");

            migrationBuilder.AlterColumn<string>(
                name: "MarkerId",
                table: "SiteMarkerImages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
