using courses.Interfaces;
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
	}
}
