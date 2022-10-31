using Microsoft.EntityFrameworkCore.Migrations;

namespace TermProjectX.Migrations
{
    public partial class Annotations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SCPs_ObjectClasses_ObjectClassID",
                table: "SCPs");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectClassID",
                table: "SCPs",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Containment",
                table: "SCPs",
                maxLength: 1500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ObjectClasses",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SCPs_ObjectClasses_ObjectClassID",
                table: "SCPs",
                column: "ObjectClassID",
                principalTable: "ObjectClasses",
                principalColumn: "ObjectClassId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SCPs_ObjectClasses_ObjectClassID",
                table: "SCPs");

            migrationBuilder.AlterColumn<string>(
                name: "ObjectClassID",
                table: "SCPs",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Containment",
                table: "SCPs",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 1500);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ObjectClasses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_SCPs_ObjectClasses_ObjectClassID",
                table: "SCPs",
                column: "ObjectClassID",
                principalTable: "ObjectClasses",
                principalColumn: "ObjectClassId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
