using courses.Interfaces;
using courses.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace courses.Controllers
{
	public class UserController : Controller
	{
		private readonly IUsersRepository usersRepository;

		public UserController(IUsersRepository usersRepository)
		{
			this.usersRepository = usersRepository;
		} 

		public IActionResult Register(string returnUrl)
		{
			return View();
		}

		[HttpPost]
		public IActionResult Register(RegistrationViewModel model)
		{
			return View();
		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
