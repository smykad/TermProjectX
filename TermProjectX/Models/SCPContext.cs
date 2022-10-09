using Microsoft.EntityFrameworkCore;

namespace TermProjectX.Models
{
    public class SCPContext : DbContext
    {
        public SCPContext(DbContextOptions<SCPContext> options) : base(options) { }
        public DbSet<SCP> SCPs { get; set; }
        public DbSet<ObjectClass> ObjectClasses{ get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ObjectClass>().HasData(
                new ObjectClass { ObjectClassId = "S", Name = "Safe" },
                new ObjectClass { ObjectClassId = "E", Name = "Euclid" }

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
                    ObjectClassID = "E"
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
                    ObjectClassID = "S"
                },
                new SCP
                {
                    ID = 3,
                    Name = "SPC-1271",
                    Description = "SCP-1271 is a square tract of land approximately 20 m on each side, roughly landscaped into a " +
                        "functional kickball field. The field comprised a portion of the grounds of Sheckler Elementary School in " +
                        "Catasauqua, PA, before the school was closed in 1967. The grounds have been abandoned ever since.",
                    Containment = "Fencing",
                    ObjectClassID = "E"
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
                    ObjectClassID = "S"
                }

            );
        }
    }
}
