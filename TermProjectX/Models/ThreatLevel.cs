using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TermProjectX.Models
{
    
    public class ThreatLevel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ThreatLevelId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only alphabetic letters are allowed.")]
        public string Name { get; set; }
    }
}
