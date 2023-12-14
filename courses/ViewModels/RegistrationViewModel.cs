using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace courses.ViewModels
{
	public class RegistrationViewModel
	{
		[Required(ErrorMessage = "(это поле является обязательным)")]
		[MaxLength(15)]
		[Display(Name = "Имя")]
		public string Name { get; set; } = null!;

		//[Required]
		[MaxLength(15)]
		[Display(Name = "Имя")]
		public string? Surname { get; set; }

        [Required(ErrorMessage = "(это поле является обязательным)")]
        [Display(Name = "Email")]
		[EmailAddress]
		public string Email { get; set; } = null!;

        [Required(ErrorMessage = "(это поле является обязательным)")]
        [DataType(DataType.Password)]
		[Display(Name = "Пароль")]
		public string Password { get; set; } = null!;

        [Required(ErrorMessage = "(это поле является обязательным)")]
        [DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "Пароли не совпадают")]
		[Display(Name = "Подтвердите пароль")]
		public string ConfirmPassword { get; set; } = null!;

		//public string ReturnUrl { get; set; }
	}
}
