using courses.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace courses.Controllers
{
	public class ModuleController : Controller
	{
		private readonly IModulesRepository modulesRepository;

		public ModuleController(IModulesRepository modulesRepository)
		{
				this.modulesRepository = modulesRepository;
		}
		public IActionResult Index(int id)
		{
			var module = modulesRepository.Get(id);
			return View(module);
		}

		[Authorize]
		[HttpPost]
		public IActionResult Delete(int id)
		{
			var module = modulesRepository.Get(id);
			if (module != null)
			{
				modulesRepository.Delete(module);
			}
			return RedirectToAction("OwnCourses", "User");
		}

		public IActionResult Edit(int id)
		{
			return View();
		}
	}
}
