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
            return context.Courses;
        }

		public Course GetCourse(int id)
		{
            return context.Courses.Include(c => c.Modules).FirstOrDefault(c => c.Id == id);
		}

        public bool AddStudent(User user, Course course)
        {
            try
            {
                course.Students.Add(user);
                context.SaveChanges();
                return true;
            } catch (Exception ex)
            {
				course.Students.Remove(user);
                return false;
			}
        }
	}
}
