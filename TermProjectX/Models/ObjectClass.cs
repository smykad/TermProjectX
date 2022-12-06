using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TermProjectX.Models
{
    [DisplayName("Object Class")]
    public class ObjectClass
    {
        [Key]
      
        public int ObjectClassId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only alphabetic letters are allowed.")]
    
        public string Name { get; set; }
    }
}
