using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IndoorNavigation.Persistence.Migrations
{
    public partial class newColAddedInSiteAndmarkerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BlobUrl",
                table: "MapMarkers",
                newName: "MapMarkerBlobUrl");

            migrationBuilder.AddColumn<double>(
                name: "SiteMapBreadth",
                table: "Sites",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SiteMapImageHeight",
                table: "Sites",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SiteMapImageWidth",
                table: "Sites",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SiteMapLength",
                table: "Sites",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "SiteMapUrl",
                table: "Sites",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "MarkerHeight",
                table: "MapMarkers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MarkerScanAngle",
                table: "MapMarkers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MarkerWidth",
                table: "MapMarkers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Marker_XPos",
                table: "MapMarkers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Marker_YPos",
                table: "MapMarkers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SiteMapBreadth",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "SiteMapImageHeight",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "SiteMapImageWidth",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "SiteMapLength",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "SiteMapUrl",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "MarkerHeight",
                table: "MapMarkers");

            migrationBuilder.DropColumn(
                name: "MarkerScanAngle",
                table: "MapMarkers");

            migrationBuilder.DropColumn(
                name: "MarkerWidth",
                table: "MapMarkers");

            migrationBuilder.DropColumn(
                name: "Marker_XPos",
                table: "MapMarkers");

            migrationBuilder.DropColumn(
                name: "Marker_YPos",
                table: "MapMarkers");

            migrationBuilder.RenameColumn(
                name: "MapMarkerBlobUrl",
                table: "MapMarkers",
                newName: "BlobUrl");
        }
    }
}
