using EngLine.DataAccess;
using EngLine.Models;
using Microsoft.EntityFrameworkCore;

namespace EngLine.Repositories.EF
{
	public class EFCourseRepository : ICourseRepository
	{
		private readonly EngLineContext _context;

		public EFCourseRepository(EngLineContext context)
		{
			_context = context;
		}

		public async Task AddCourseAsync(Course course)
		{
			_context.Courses.Add(course);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteCourseAsync(int id)
		{
			var course = await _context.Courses
				.Include(c => c.Teacher)
				.Include(c => c.Lessons)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (course != null)
			{
				course.IsDelete = true;
				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<Course>> GetAllCourseAsync()
		{
			return await _context.Courses
				.Include(c => c.Teacher)
				.Include(c => c.Lessons)
				.Where(c => !c.IsDelete)
				.ToListAsync();
		}

		public async Task<IEnumerable<Course>> GetAllCourseByIdTeacherAsync(string id)
		{
			return await _context.Courses
				.Where(c => c.TeacherId == id && !c.IsDelete)
				.Include(c => c.Teacher)
				.Include(c => c.Lessons)
				.Take(5)
				.ToListAsync();
		}

		public async Task<Course> GetCourseByIdAsync(int id)
		{
			return await _context.Courses
				.Include(c => c.Lessons)
				.Include(c => c.Teacher)
				.FirstOrDefaultAsync(c => c.Id == id && !c.IsDelete);
		}

		public async Task UpdateCourseAsync(Course course)
		{
			_context.Courses.Update(course);
			await _context.SaveChangesAsync();
		}
	}
}
