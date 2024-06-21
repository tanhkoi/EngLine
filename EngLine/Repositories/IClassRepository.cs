using EngLine.Models;

namespace EngLine.Repositories
{
	public interface IClassRepository
	{
		Task<IEnumerable<Class>> GetAllAsync();
		Task<Class> GetByIdAsync(int id);
		Task AddAsync(Class category);
		Task UpdateAsync(Class category);
		Task DeleteAsync(int id);
	}
}
