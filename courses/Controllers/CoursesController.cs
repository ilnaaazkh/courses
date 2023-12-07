using courses.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace courses.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext context;
        CoursesController(ApplicationDbContext context) {
            this.context = context;
        }
        public IActionResult Index()
        {
            var courses = context.Courses.ToList();
            return View(courses);
        }
    }
}
