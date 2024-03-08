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
			try
			{
				context.Courses.Add(entity);
				context.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Delete(Course entity)
		{
			try
			{
				context.Remove(entity);
				context.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public IEnumerable<Course> GetAll()
		{
			try
			{
				return context.Courses;
			}
			catch
			{
				return Enumerable.Empty<Course>(); ;
			}
		}

		public Course Get(int id)
		{
			try
			{
				return context.Courses.Include(c => c.Modules).FirstOrDefault(c => c.Id == id);
			}
			catch
			{
				return null;
			}
		}

		public bool AddStudent(User user, Course course)
		{
			try
			{
				course.Students.Add(user);
				context.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				course.Students.Remove(user);
				return false;
			}
		}

		public Course GetCourseWithAuthors(int id)
		{
			try
			{
				return context.Courses.Include(c => c.Authors).Include(c => c.Modules).FirstOrDefault(c => c.Id == id);
			}
			catch
			{
				return null;
			}
		}

		public bool Update(Course entity, Action<Course> update)
		{
			try
			{
				update(entity);
				context.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
