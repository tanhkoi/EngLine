using EngLine.DataAccess;
using EngLine.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EngLine.Repositories
{
	public class EFCourseRepository : ICourseRepository
	{
		private readonly EngLineContext _context;

		public EFCourseRepository(EngLineContext context)
		{
			_context = context;
		}

		public async Task Add(Course course)
		{
			_context.Courses.Add(course);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			var courseToDelete = await _context.Courses.FindAsync(id);
			if (courseToDelete != null)
			{
				courseToDelete.IsDelete = true;
				_context.Entry(courseToDelete).State = EntityState.Modified;
				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<Course>> GetAll()
		{
			return await _context.Courses.ToListAsync();
		}

		public async Task<Course> GetById(int id)
		{
			return await _context.Courses.FindAsync(id);
		}

		public async Task Update(Course course)
		{
			_context.Entry(course).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}
	}
}
