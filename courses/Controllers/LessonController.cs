using courses.Interfaces;
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
	}
}
