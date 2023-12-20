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

		public Module Get(int id)
		{
			return context.Modules.Include(module => module.Lessons).Where(module => module.Id == id).First();
		}

		public IEnumerable<Module> GetAll()
		{
			throw new NotImplementedException();
		}

		public bool Update(Module entity, Action<Module> update)
		{
			throw new NotImplementedException();
		}
	}
}
