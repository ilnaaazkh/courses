using courses.Data;
using courses.Interfaces;
using courses.Models;
using Microsoft.AspNetCore.Mvc;

namespace courses.Repositories
{
	public class LessonsRepository : ILessonsRepository
	{
		private readonly ApplicationDbContext context;
		public LessonsRepository(ApplicationDbContext context)
		{
			this.context = context;
		}
		public bool Create(Lesson entity)
		{
			throw new NotImplementedException();
		}

		public bool Delete(Lesson entity)
		{
			throw new NotImplementedException();
		}

		public Lesson Get(int id)
		{
			return context.Lessons.Where(lesson => lesson.Id == id).First();
		}

		public IEnumerable<Lesson> GetAll()
		{
			throw new NotImplementedException();
		}

		public bool Update(Lesson entity, Action<Lesson> update)
		{
			throw new NotImplementedException();
		}
	}
}
