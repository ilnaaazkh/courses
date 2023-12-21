using courses.Data;
using courses.Interfaces;
using courses.Models;
using Microsoft.EntityFrameworkCore;

namespace courses.Repositories
{
	public class UsersRepository : IUsersRepository
	{
		private readonly ApplicationDbContext context;

		public UsersRepository(ApplicationDbContext context)
		{
			this.context = context;
		}

		public bool Create(User entity)
		{
			try
			{
				var result = context.Users.Add(entity);
				var res = context.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Delete(User entity)
		{
			throw new NotImplementedException();
		}

		public User Get(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<User> GetAll()
		{
			throw new NotImplementedException();
		}

		public User GetUserWithCourses(int id)
		{
			try
			{
				User user = context.Users.Include(user => user.Courses).Where(user => user.Id == id).First();
				return user;
			}
			catch
			{
				return null;
			}
		}

		public User GetUserWithOwnCourses(int id)
		{
			try
			{
				User user = context.Users.Include(user => user.CoursesAuthorship).Where(user => user.Id == id).First();
				return user;
			}
			catch
			{
				return null;
			}
		}

		public bool Update(User entity, Action<User> update)
		{
			throw new NotImplementedException();
		}
	}
}
