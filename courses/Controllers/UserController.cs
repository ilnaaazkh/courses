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
		private readonly UserManager<User> userManager;
		private readonly SignInManager<User> signInManager;

		public UserController(IUsersRepository usersRepository,
				UserManager<User> userManager,
				SignInManager<User> signInManager)
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
		public async Task<IActionResult> Register(RegistrationViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			User user = new User() { UserName = model.Email, Name = model.Name, Surname = model.Surname, Email = model.Email };
			IdentityResult result = await userManager.CreateAsync(user, model.Password);

			if (result.Succeeded)
			{
				return RedirectToAction("Login", "User"); ;
			}
			return View();
		}

		[AllowAnonymous]
		public IActionResult Login(string returnUrl)
		{
			ViewBag.returnUrl = returnUrl == null ? "/" : returnUrl;
			return View();
		}


		//ilnaz.khuzin2016@gmail.com
		//Demo1234
		[HttpPost]
		[AllowAnonymous]
		public async Task<IActionResult> LoginAsync(LoginViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var user = await userManager.FindByNameAsync(model.Email); //Email == UserName

			var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);
			if (result.Succeeded)
			{
				return Redirect(model.ReturnUrl);
			}

			return View(model);
		}

		public async Task<IActionResult> LogOutAsync()
		{
			await signInManager.SignOutAsync();
			return Redirect("/");
		}

		public async Task<IActionResult> Manage()
		{
			User user = await userManager.FindByEmailAsync(User.Identity.Name);

			if (user != null)
			{
				ManageViewModel model = new ManageViewModel()
				{
					Name = user.Name,
					Surname = user.Surname
				};
				return View(model);
			}
			return RedirectToAction("Login", "User");
		}

		[HttpPost]
		public async Task<IActionResult> ManageAsync(ManageViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			User user = await userManager.FindByEmailAsync(User.Identity.Name);
			if(user != null)
			{
				user.Name = model.Name;
				user.Surname = model.Surname;
				

				IdentityResult result = await userManager.UpdateAsync(user);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Courses");
				}
				else
				{
					ModelState.AddModelError("", "Что-то пошло не так");
				}
			}
			else
			{
				ModelState.AddModelError("", "Пользователь не найден");
			}
			return View(model);
		}

		public IActionResult Index()
		{
			return View();
		}
	}
}
