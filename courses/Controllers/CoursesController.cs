using courses.Data;
using courses.Interfaces;
using courses.Models;
using courses.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace courses.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICoursesRepository coursesRepository;
		private readonly UserManager<User> userManager;

		public CoursesController(ICoursesRepository coursesRepository,
            UserManager<User> userManager)
        {
            this.coursesRepository = coursesRepository;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {   
            ViewBag.Courses = coursesRepository.GetAll();
            return View();
        }

        public async Task<IActionResult> CourseAsync(int id)
        {
            var course = coursesRepository.GetCourse(id);
            if(course == null)
            {
                return Redirect("/courses/index"); ;
            }

            if (User.Identity.IsAuthenticated)
            {
                var user = await userManager.FindByEmailAsync(User.Identity.Name);
                coursesRepository.AddStudent(user, course);
            }

            ViewBag.Course = course;
            return View();
        }
    }
}
