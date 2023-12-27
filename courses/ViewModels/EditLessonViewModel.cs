using System.ComponentModel.DataAnnotations;

namespace courses.ViewModels
{
	public class EditLessonViewModel
	{
		[Required]
		public int Id { get; set; }

		[Required]
		public string Title { get; set; }

		[Required]
		public string Content { get; set; }

		[Required]
		public int OrderNumber { get; set; }

		[Required]
		public int ModuleId { get; set; }
	}
}
