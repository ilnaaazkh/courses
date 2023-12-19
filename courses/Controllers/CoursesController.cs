using courses.Data;
using courses.Interfaces;
using courses.Migrations;
using courses.Models;
using courses.Repositories;
using courses.ViewModels;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateAsync(CourseCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(User.Identity.Name);
                var course = new Course() { Title = model.Title, Description = model.Description};
                course.Authors.Add(user);
                coursesRepository.Create(course);

            }
            return RedirectToAction("OwnCourses", "User");
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await userManager.FindByEmailAsync(User.Identity.Name);
            var course = coursesRepository.GetCourseWithAuthors(id);
            if (course != null && course.Authors.Any(author => author.Id == user.Id))
            {
                coursesRepository.Delete(course); 
            }
            return RedirectToAction("OwnCourses", "User");
        }

        [Authorize]
        public IActionResult Edit(int id)
        {

            return View();
        }
    }
}
