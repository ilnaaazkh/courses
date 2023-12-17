using System.ComponentModel.DataAnnotations;

namespace courses.ViewModels
{
	public class ManageViewModel
	{
		[Required(ErrorMessage = "(это поле обязательно)")]
		[MaxLength(15)]
		public string Name { get; set; } = null!;

		[MaxLength(15)]
		public string? Surname { get; set; }
	}
}
