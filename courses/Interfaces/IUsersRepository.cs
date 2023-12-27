using courses.Models;

namespace courses.Interfaces
{
	public interface IUsersRepository : IRepository<User>
	{
		User GetUserWithCourses(int id);

		User GetUserWithOwnCourses(int id);
	}
}
