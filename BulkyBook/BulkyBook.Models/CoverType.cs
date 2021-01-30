using System.ComponentModel.DataAnnotations;

namespace BulkyBook.Models
{
    public class CoverType
    {
        public int Id { get; set; }

        [Display(Name = "Cover Type Name")]
        [Required]
        [MaxLength(40)]
        public string Name { get; set; }
    }
}