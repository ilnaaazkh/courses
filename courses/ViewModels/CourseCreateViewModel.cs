using System.ComponentModel.DataAnnotations;

namespace courses.ViewModels
{
    public class CourseCreateViewModel
    {
        [Required(ErrorMessage = "(это поле обязательно)")]
        [MaxLength(50)]
        public string Title { get; set; } = null!;

        [MaxLength(400)]
        public string? Description { get; set; }
    }
}