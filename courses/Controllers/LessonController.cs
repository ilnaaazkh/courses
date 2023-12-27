using courses.Interfaces;
using courses.Models;
using courses.Repositories;
using courses.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace courses.Controllers
{
	public class LessonController : Controller
	{

		private readonly ILessonsRepository lessonsRepository;

		public LessonController(ILessonsRepository lessonsRepository)
		{
			this.lessonsRepository = lessonsRepository;
		}

		public IActionResult Index(int id)
		{
			var lesson = lessonsRepository.Get(id);
			return View(lesson);
		}

		[Authorize]
		public IActionResult Edit(int id){
			var course = lessonsRepository.Get(id);
			if (course == null)
			{
				return RedirectToAction("Edit", "Module");
			}

			var model = new EditLessonViewModel() {
				Id = course.Id,
				Title = course.Title,
				Content = course.Content,
				OrderNumber = course.OrderNumber,
				ModuleId = course.ModuleId
			};

			return View(model);
		}

		[Authorize]
		[HttpPost]
		public IActionResult Edit(EditLessonViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			var lesson = lessonsRepository.Get(model.Id);
			if (lesson != null)
			{
				lessonsRepository.Update(lesson, lesson =>
				{
					lesson.OrderNumber = model.OrderNumber;
					lesson.Content = model.Content;
					lesson.Title = model.Title;
				});
			}
			return Redirect($"/Module/Edit/{model.ModuleId}");
		}

		[Authorize]
		public IActionResult Create(int moduleId)
		{
			ViewBag.ModuleId = moduleId;
			return View();
		}

		[Authorize]
		[HttpPost]
		public IActionResult Create(EditLessonViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var lesson = new Lesson()
			{
				Content = model.Content,
				OrderNumber = model.OrderNumber,
				ModuleId = model.ModuleId,
				Title = model.Title
			};

			lessonsRepository.Create(lesson);
			return Redirect($"/Module/Edit/{model.ModuleId}");
		}

		[Authorize]
		[HttpPost]
		public IActionResult Delete(int id)
		{
			var lesson = lessonsRepository.Get(id);
			if(lesson != null)
			{
				lessonsRepository.Delete(lesson);
				return Redirect($"/Module/Edit/{lesson.ModuleId}");
			}
			return Redirect($"/");
		}
	}
}
