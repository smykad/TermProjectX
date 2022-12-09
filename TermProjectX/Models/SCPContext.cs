using Microsoft.EntityFrameworkCore;

namespace TermProjectX.Models
{
    public class SCPContext : DbContext
    {
        public SCPContext(DbContextOptions<SCPContext> options) : base(options) { }
        public DbSet<SCP> SCPs { get; set; }
        public DbSet<ObjectClass> ObjectClasses { get; set; }
        public DbSet<ThreatLevel> ThreatLevels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<ThreatLevel>().HasData(
                new ThreatLevel { ThreatLevelId = -1, Name = "Green", Description = "The object is not beneficial, but isn't harmful as long as it is handled correctly. Often assigned to Safe and Euclid class objects." },
                new ThreatLevel { ThreatLevelId = -2, Name = "Blue", Description = "The object might be beneficial, but its mechanisms are poorly understood or remain unknown. This applies to items with undefined properties or to entities that react differently to different individuals. Often assigned to Safe and Euclid class objects." }

            );
            modelBuilder.Entity<ObjectClass>().HasData(
                new ObjectClass { ObjectClassId = -1, Name = "Safe", Description = "Safe-class SCPs are anomalies that are easily and safely contained. This is often due to the fact that the Foundation has researched the SCP well enough that containment does not require significant resources or that the anomalies require a specific and conscious activation or trigger. Classifying an SCP as Safe, however, does not mean that handling or activating it does not pose a threat." },
                new ObjectClass { ObjectClassId = -2, Name = "Euclid", Description = "Euclid-class SCPs are anomalies that require more resources to contain completely or where containment isn't always reliable. Usually this is because the SCP is insufficiently understood or inherently unpredictable. Euclid is the Object Class with the greatest scope, and it's usually a safe bet that an SCP will be this class if it doesn't easily fall into any of the other standard Object Classes." }

            );
            modelBuilder.Entity<SCP>().HasData(
                new SCP
                {
                    ID = 1,
                    Name = "SCP-5581",
                    Description = "SCP-5881 refers to Ben Hennessy, a 26 year old British male, who subconsciously manifests three " +
                        "Class 2 incorporeal entities that resemble different versions of himself. These instances manifest around " +
                        "SCP-5881 and converse with him for any amount of time between 2 minutes to 5 hours. These conversations " +
                        "involve SCP-5881 being instructed on a variety of subjects, including mathematics, computer science, " +
                        "ancient and modern history, science, physical education and various life and social skills. SCP-5881 " +
                        "manifestations previously occurred a minimum of once every two hours, and a maximum of once every three days. " +
                        "Only one instance can manifest at a time.",
                    Containment = "Standard human containment cell",
                    ObjectClassID = -1,
                    ThreatLevelID = -1
                },
                new SCP
                {
                    ID = 2,
                    Name = "SCP-6567",
                    Description = "Roughly 39cm in length and 34cm in height. " +
                        "Despite lacking the proper bodily structures for human speech, SCP-6567 is a proficient speaker of both " +
                        "the English and Italian languages. SCP-6567 refers to itself as 'Eduardo Uccello, ' a self " +
                        "proclaimed, former Italian-American mafia underboss. Despite inhibiting the entity's ability to fly, " +
                        "the entity always adorns a pigeon tailored Armani blue-gray striped suit and tie as well as a dark gray " +
                        "fedora while outside of its enclosure. When asked how it acquired such apparel, SCP-6567 explained that " +
                        "it was,  'A gift from some of my subordinates. '",
                    Containment = "Wooden Pigeon Coop",
                    ObjectClassID = -2,
                    ThreatLevelID = -2
                },
                new SCP
                {
                    ID = 3,
                    Name = "SPC-1271",
                    Description = "SCP-1271 is a square tract of land approximately 20 m on each side, roughly landscaped into a " +
                        "functional kickball field. The field comprised a portion of the grounds of Sheckler Elementary School in " +
                        "Catasauqua, PA, before the school was closed in 1967. The grounds have been abandoned ever since.",
                    Containment = "Fencing",
                    ObjectClassID = -1,
                    ThreatLevelID = -1

                },
                new SCP
                {

                    ID = 4,
                    Name = "SCP-189",
                    Description = "SCP-189 is a species of parasitic roundworm (tentative taxonomic classification [DATA EXPUNGED]) " +
                        "capable of infesting any mammalian life form. Infection most commonly occurs as a result of direct skin contact " +
                        "with one or more egg sacs. These egg sacs are covered with microscopic \"hooks\" similar to those on the cuticles " +
                        "of some species of nematode, which anchor the sacs to the skin's surface. Contact with sebum then prompts the eggs " +
                        "inside to hatch, at which time the larvae seek out and burrow into one or more nearby hair follicles.",
                    Containment = "Cryo-containment Facility",
                    ObjectClassID = -2,
                    ThreatLevelID = -2
                }

            );
        }
    }
}
