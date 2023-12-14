using courses.Interfaces;
using courses.Models;
using courses.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace courses.Controllers
{
	[Authorize]
	public class UserController : Controller
	{
		private readonly IUsersRepository usersRepository;
		private readonly UserManager<Student> userManager;
		private readonly SignInManager<Student> signInManager;

		public UserController(IUsersRepository usersRepository, 
				UserManager<Student> userManager,
				SignInManager<Student> signInManager)
		{
			this.usersRepository = usersRepository;
			this.userManager = userManager;
			this.signInManager = signInManager;
		}

		[AllowAnonymous]
		public IActionResult Register(string returnUrl)
		{
			return View();
		}

		[HttpPost]
		[AllowAnonymous]
		public IActionResult Register(RegistrationViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}



			return View();
		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
