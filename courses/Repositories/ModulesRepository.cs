using courses.Data;
using courses.Interfaces;
using courses.Models;
using Microsoft.EntityFrameworkCore;

namespace courses.Repositories
{
	public class ModulesRepository : IModulesRepository
	{
		private readonly ApplicationDbContext context;

		public ModulesRepository(ApplicationDbContext context)
		{
			this.context = context;
		}

		public bool Create(Module entity)
		{
			throw new NotImplementedException();
		}

		public bool Delete(Module entity)
		{
			throw new NotImplementedException();
		}

		public Module Get(int id)
		{
			return context.Modules.Include(module => module.Lessons).Where(module => module.Id == id).First();
		}

		public IEnumerable<Module> GetAll()
		{
			throw new NotImplementedException();
		}
	}
}
