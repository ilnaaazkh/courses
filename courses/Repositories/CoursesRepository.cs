using courses.Data;
using courses.Interfaces;
using courses.Models;
using Microsoft.EntityFrameworkCore;

namespace courses.Repositories
{
    public class CoursesRepository : ICoursesRepository
    {
        private readonly ApplicationDbContext context;
        public CoursesRepository(ApplicationDbContext context) 
        {
            this.context = context; 
        }

        public bool Create(Course entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Course entity)
        {
            throw new NotImplementedException();
        }

        public Course Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> Select()
        {
            return context.Courses.ToList();
        }
    }
}
