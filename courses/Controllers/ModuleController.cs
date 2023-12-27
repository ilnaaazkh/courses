using courses.Interfaces;
using courses.Models;
using courses.ViewModels;
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

		[Authorize]
		public IActionResult Edit(int id)
		{
			var module = modulesRepository.Get(id);
			if (module == null)
			{
				return RedirectToAction("OwnCourses", "User");
			}
			var model = new EditModuleViewModel()
			{
				Id = module.Id,
				Description = module.Description,
				Title = module.Title,
				OrderNumber = module.OrderNumber,
				CourseId = module.CourseId,
				Lessons = module.Lessons
			};
			return View(model);
		}

		[Authorize]
		[HttpPost]
		public IActionResult Edit(EditModuleViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var module = modulesRepository.Get(model.Id);
			if(module != null)
			{
				modulesRepository.Update(module, (module) =>
				{
					module.Title = model.Title;
					module.OrderNumber = model.OrderNumber;
					module.Description = model.Description;
				});
			}

			return Redirect($"/Courses/Edit/{model.CourseId}");
		}

		[Authorize]
		public IActionResult Create(int courseId)
		{
			ViewBag.CourseId = courseId;
			return View();
		}

		[Authorize]
		[HttpPost]
		public IActionResult Create(EditModuleViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var module = new Module()
			{
				Title = model.Title,
				Description = model.Description,
				OrderNumber = model.OrderNumber,
				CourseId = model.CourseId
			};

			modulesRepository.Create(module);

			return Redirect($"/Courses/Edit/{model.CourseId}");
		}
	}
}
