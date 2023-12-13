namespace courses.ViewModels
{
	public class RegistrationViewModel
	{
		public string Name { get; set; }

		public string? Surname { get; set; }

		public string Email { get; set; }

		public string Password { get; set; }

		public string ConfirmPassword { get; set; }

		public string ReturnUrl { get; set; }
	}
}
