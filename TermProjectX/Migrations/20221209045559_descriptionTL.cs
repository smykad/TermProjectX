using Microsoft.EntityFrameworkCore.Migrations;

namespace TermProjectX.Migrations
{
    public partial class descriptionTL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ThreatLevels",
                maxLength: 1500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ThreatLevels",
                keyColumn: "ThreatLevelId",
                keyValue: -2,
                column: "Description",
                value: "The object might be beneficial, but its mechanisms are poorly understood or remain unknown. This applies to items with undefined properties or to entities that react differently to different individuals. Often assigned to Safe and Euclid class objects.");

            migrationBuilder.UpdateData(
                table: "ThreatLevels",
                keyColumn: "ThreatLevelId",
                keyValue: -1,
                column: "Description",
                value: "The object is not beneficial, but isn't harmful as long as it is handled correctly. Often assigned to Safe and Euclid class objects.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ThreatLevels");
        }
    }
}
