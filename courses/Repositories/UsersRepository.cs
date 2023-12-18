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
			var result = context.Users.Add(entity);
			var res = context.SaveChanges();
			return true;
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
			User user = context.Users.Include(user => user.Courses).Where(user => user.Id == id).First();
			return user;
		}
	}
}
