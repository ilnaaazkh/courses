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
			try
			{
				context.Modules.Add(entity);
				context.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
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
			try
			{
				return context.Modules.Where(module => module.Id == id)
					.Include(module => module.Course)
					.Include(module => module.Lessons).First();
			}
			catch
			{
				return null;
			}
		}

		public IEnumerable<Module> GetAll()
		{
			throw new NotImplementedException();
		}

		public bool Update(Module entity, Action<Module> update)
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
