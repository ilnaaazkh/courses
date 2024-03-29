﻿using courses.Data;
using courses.Interfaces;
using courses.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
			try
			{
				context.Lessons.Add(entity);
				context.SaveChanges();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public bool Delete(Lesson entity)
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

		public Lesson Get(int id)
		{
			try
			{
				return context.Lessons.Where(lesson => lesson.Id == id)
					.Include(lesson => lesson.Module)
					.First();
			}
			catch
			{
				return null;
			}
		}

		public IEnumerable<Lesson> GetAll()
		{
			try
			{
				return context.Lessons;
			}
			catch
			{
				return Enumerable.Empty<Lesson>(); ;
			}
		}

		public bool Update(Lesson entity, Action<Lesson> update)
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
