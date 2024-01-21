using System.ComponentModel.DataAnnotations;

namespace Exam_Project.Models
{
    public class Service
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2), MaxLength(32)]
        public string Name { get; set; }
        [Required]
        public string Image { get; set; }
    }
}
