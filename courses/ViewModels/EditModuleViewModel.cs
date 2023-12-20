using courses.Models;
using System.ComponentModel.DataAnnotations;

namespace courses.ViewModels
{
	public class EditModuleViewModel
	{
		[Required]
		public int CourseId { get; set; }

		[Required]
		public int Id { get; set; }

		[Required]
		[MaxLength(70)]
		public string Title { get; set; } = null!;

		[MaxLength(200)]
		public string? Description { get; set; }

		[Required]
		public int OrderNumber { get; set; }

		public List<Lesson> Lessons { get; set; } = new();
	}
}
