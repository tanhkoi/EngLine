using EngLine.DataAccess;
using EngLine.Models;

namespace EngLine.Repositories.EF
{
	public class EFCourseRepository : ICourseRepository
	{
		private readonly EngLineContext _context;

		public EFCourseRepository(EngLineContext context)
		{
			_context = context;
		}

		public Task AddCourseAsync(Course course)
		{
			throw new NotImplementedException();
		}

		public Task DeleteCourseAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Course>> GetAllCourseAsync()
		{
			throw new NotImplementedException();
		}

		public Task<Course> GetCourseByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task UpdateCourseAsync(Course course)
		{
			throw new NotImplementedException();
		}
	}
}
