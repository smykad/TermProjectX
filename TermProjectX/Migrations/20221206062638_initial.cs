using Microsoft.EntityFrameworkCore.Migrations;

namespace TermProjectX.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObjectClasses",
                columns: table => new
                {
                    ObjectClassId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectClasses", x => x.ObjectClassId);
                });

            migrationBuilder.CreateTable(
                name: "ThreatLevels",
                columns: table => new
                {
                    ThreatLevelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThreatLevels", x => x.ThreatLevelId);
                });

            migrationBuilder.CreateTable(
                name: "SCPs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    Description = table.Column<string>(maxLength: 1500, nullable: false),
                    Containment = table.Column<string>(maxLength: 1500, nullable: false),
                    ObjectClassID = table.Column<int>(nullable: false),
                    ThreatLevelID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SCPs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SCPs_ObjectClasses_ObjectClassID",
                        column: x => x.ObjectClassID,
                        principalTable: "ObjectClasses",
                        principalColumn: "ObjectClassId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SCPs_ThreatLevels_ThreatLevelID",
                        column: x => x.ThreatLevelID,
                        principalTable: "ThreatLevels",
                        principalColumn: "ThreatLevelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ObjectClasses",
                columns: new[] { "ObjectClassId", "Name" },
                values: new object[,]
                {
                    { -1, "Safe" },
                    { -2, "Euclid" }
                });

            migrationBuilder.InsertData(
                table: "ThreatLevels",
                columns: new[] { "ThreatLevelId", "Name" },
                values: new object[,]
                {
                    { -1, "Green" },
                    { -2, "Blue" }
                });

            migrationBuilder.InsertData(
                table: "SCPs",
                columns: new[] { "ID", "Containment", "Description", "Name", "ObjectClassID", "ThreatLevelID" },
                values: new object[,]
                {
                    { 1, "Standard human containment cell", "SCP-5881 refers to Ben Hennessy, a 26 year old British male, who subconsciously manifests three Class 2 incorporeal entities that resemble different versions of himself. These instances manifest around SCP-5881 and converse with him for any amount of time between 2 minutes to 5 hours. These conversations involve SCP-5881 being instructed on a variety of subjects, including mathematics, computer science, ancient and modern history, science, physical education and various life and social skills. SCP-5881 manifestations previously occurred a minimum of once every two hours, and a maximum of once every three days. Only one instance can manifest at a time.", "SCP-5581", -1, -1 },
                    { 3, "Fencing", "SCP-1271 is a square tract of land approximately 20 m on each side, roughly landscaped into a functional kickball field. The field comprised a portion of the grounds of Sheckler Elementary School in Catasauqua, PA, before the school was closed in 1967. The grounds have been abandoned ever since.", "SPC-1271", -1, -1 },
                    { 2, "Wooden Pigeon Coop", "Roughly 39cm in length and 34cm in height. Despite lacking the proper bodily structures for human speech, SCP-6567 is a proficient speaker of both the English and Italian languages. SCP-6567 refers to itself as 'Eduardo Uccello, ' a self proclaimed, former Italian-American mafia underboss. Despite inhibiting the entity's ability to fly, the entity always adorns a pigeon tailored Armani blue-gray striped suit and tie as well as a dark gray fedora while outside of its enclosure. When asked how it acquired such apparel, SCP-6567 explained that it was,  'A gift from some of my subordinates. '", "SCP-6567", -2, -2 },
                    { 4, "Cryo-containment Facility", "SCP-189 is a species of parasitic roundworm (tentative taxonomic classification [DATA EXPUNGED]) capable of infesting any mammalian life form. Infection most commonly occurs as a result of direct skin contact with one or more egg sacs. These egg sacs are covered with microscopic \"hooks\" similar to those on the cuticles of some species of nematode, which anchor the sacs to the skin's surface. Contact with sebum then prompts the eggs inside to hatch, at which time the larvae seek out and burrow into one or more nearby hair follicles.", "SCP-189", -2, -2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SCPs_ObjectClassID",
                table: "SCPs",
                column: "ObjectClassID");

            migrationBuilder.CreateIndex(
                name: "IX_SCPs_ThreatLevelID",
                table: "SCPs",
                column: "ThreatLevelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SCPs");

            migrationBuilder.DropTable(
                name: "ObjectClasses");

            migrationBuilder.DropTable(
                name: "ThreatLevels");
        }
    }
}
