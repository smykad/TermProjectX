using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TermProjectX.Models
{
    [DisplayName("Threat Level")]
    public class ThreatLevel
    {
        [Key]
        public int ThreatLevelId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only alphabetic letters are allowed.")]
        public string Name { get; set; }

        [StringLength(1500)]
        [Required(ErrorMessage = "Must include a Description")]
        public string Description { get; set; }
    }
}
