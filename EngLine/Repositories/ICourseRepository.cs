using EngLine.Models;

namespace EngLine.Repositories
{
	public interface ICourseRepository
	{
		Task<IEnumerable<Course>> GetAllAsync();
		Task<Course> GetByIdAsync(int id);
		Task AddAsync(Course category);
		Task UpdateAsync(Course category);
		Task DeleteAsync(int id);
	}
}
