using courses.Data;
using courses.Interfaces;
using courses.Models;
using courses.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace courses.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICoursesRepository coursesRepository;

        public CoursesController(ICoursesRepository coursesRepository)
        {
            this.coursesRepository = coursesRepository;
        }

        public IActionResult Index()
        {   
            ViewBag.Courses = coursesRepository.Select();
            return View();
        }
    }
}
