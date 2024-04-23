using EngLine.Models;

namespace EngLine.Repositories
{
	public interface ICourseRepository
	{
		Task<IEnumerable<Course>> GetAll();
		Task<Course> GetById(int id);
		Task Add(Course category);
		Task Update(Course category);
		Task Delete(int id);
	}
}
