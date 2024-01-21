using System.ComponentModel.DataAnnotations;

namespace Exam_Project.Areas.Admin.ViewModels.ServiceVM
{
    public class ServiceUpdateItemVM
    {
        [Required, MinLength(3), MaxLength(32)]
        public string Name { get; set; }
        [Required]
        public IFormFile ImageFile { get; set; }
    }
}
