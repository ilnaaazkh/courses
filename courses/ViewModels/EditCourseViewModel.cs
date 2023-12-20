using courses.Models;
using System.ComponentModel.DataAnnotations;

namespace courses.ViewModels
{
    public class EditCourseViewModel
    {
		[Required]
        public int Id { get; set; }


		[Required(ErrorMessage = "(это поле обязательно)")]
		[MaxLength(50)]
		public string Title { get; set; } = null!;

		[MaxLength(400)]
		public string? Description { get; set; }

		public List<Module>? Modules { get; set; }
	}
}