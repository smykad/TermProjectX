using Microsoft.EntityFrameworkCore.Migrations;

namespace TermProjectX.Migrations
{
    public partial class descriptionOC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ObjectClasses",
                maxLength: 1500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ObjectClasses",
                keyColumn: "ObjectClassId",
                keyValue: -2,
                column: "Description",
                value: "Euclid-class SCPs are anomalies that require more resources to contain completely or where containment isn't always reliable. Usually this is because the SCP is insufficiently understood or inherently unpredictable. Euclid is the Object Class with the greatest scope, and it's usually a safe bet that an SCP will be this class if it doesn't easily fall into any of the other standard Object Classes.");

            migrationBuilder.UpdateData(
                table: "ObjectClasses",
                keyColumn: "ObjectClassId",
                keyValue: -1,
                column: "Description",
                value: "Safe-class SCPs are anomalies that are easily and safely contained. This is often due to the fact that the Foundation has researched the SCP well enough that containment does not require significant resources or that the anomalies require a specific and conscious activation or trigger. Classifying an SCP as Safe, however, does not mean that handling or activating it does not pose a threat.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ObjectClasses");
        }
    }
}
