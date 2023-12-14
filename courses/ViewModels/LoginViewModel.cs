using System.ComponentModel.DataAnnotations;

namespace courses.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Введите свой e-mail адрес")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        public string ReturnUrl { get; set; } = null!;
    }
}
