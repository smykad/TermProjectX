using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TermProjectX.Models
{
    public class SCP
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [StringLength(1500)]
        [Required]
        public string Description { get; set; }

        [StringLength(150)]
        [Required]
        public string Containment { get; set; }

        
        [Required]
        public string ObjectClassID { get; set; }
        public ObjectClass ObjectClass { get; set; }

    }
}
