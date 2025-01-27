using System.ComponentModel.DataAnnotations;

namespace school_app.Dtos
{
    public class CourseCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
