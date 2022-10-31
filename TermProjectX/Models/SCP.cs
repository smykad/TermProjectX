using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace TermProjectX.Models
{
    public class SCP
    {
        [Key]
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        [RegularExpression("^SCP+\\-+[0-9]{3,4}", ErrorMessage = "Must enter a valid name in this format 'SCP-0123'")]
        public string Name { get; set; }

        [StringLength(1500)]
        [Required(ErrorMessage = "Must include a Description")]
        public string Description { get; set; }

        [StringLength(1500)]
        [Required(ErrorMessage = "Must include Containment")]
        public string Containment { get; set; }

        [ForeignKey("ObjectClassID")]
        public string ObjectClassID { get; set; }

        [Display(Name="Object Class")]
        public ObjectClass ObjectClass { get; set; }

    }
}
