using courses.Data;
using courses.Interfaces;
using courses.Models;

namespace courses.Repositories
{
	public class UsersRepository : IUsersRepository
	{
		private readonly ApplicationDbContext context;

		public UsersRepository(ApplicationDbContext context)
		{
			this.context = context;
		}

		public bool Create(Student entity)
		{
			throw new NotImplementedException();
		}

		public bool Delete(Student entity)
		{
			throw new NotImplementedException();
		}

		public Student Get(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Student> GetAll()
		{
			throw new NotImplementedException();
		}
	}
}
