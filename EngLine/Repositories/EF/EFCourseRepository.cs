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

		public async Task<IEnumerable<Course>> GetAllCoursesAsync()
		{
			return await _context.Courses
				.Where(c => !c.IsDelete)
				.Include(c => c.Teacher)
				.Include(c => c.Lessons)
				.Include(c => c.Test)
				.ToListAsync();
		}

		public async Task<IEnumerable<Course>> GetCoursesByTeacherIdAsync(string teacherId)
		{
			return await _context.Courses
				.Where(c => c.TeacherId == teacherId && !c.IsDelete)
				.Include(c => c.Teacher)
				.Include(c => c.Lessons)
				.Include(c => c.Test)
				.ToListAsync();
		}

		public async Task<Course> GetCourseByIdAsync(int courseId)
		{
			return await _context.Courses
				.Include(c => c.Lessons)
				.Include(c => c.Teacher)
				.FirstOrDefaultAsync(c => c.Id == courseId && !c.IsDelete);
		}

		public async Task UpdateCourseAsync(Course course)
		{
			_context.Courses.Update(course);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Course>> GetPopularCoursesAsync()
		{
			var popularCourses = await _context.Courses
				.Where(c => !c.IsDelete) // Exclude deleted courses
				.Select(c => new
				{
					Course = c,
					SuccessOrderCount = c.Orders.Count(o => o.Status == "Success")
				})
				.OrderByDescending(c => c.SuccessOrderCount)
				.Select(c => c.Course)
				.Include(c => c.Teacher)
				.Include(c => c.Test)
				.ToListAsync();

			return popularCourses;
		}

		public async Task DeleteLessonsByCourseIdAsync(int courseId)
		{
			var lessons = _context.Lessons.Where(l => l.CourseId == courseId).ToList();

			_context.Lessons.RemoveRange(lessons);

			await _context.SaveChangesAsync();
		}
	}
}
