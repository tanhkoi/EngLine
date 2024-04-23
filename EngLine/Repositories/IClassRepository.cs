using EngLine.Models;

namespace EngLine.Repositories
{
	public interface IClassRepository
	{
		Task<IEnumerable<Class>> GetAll();
		Task<Class> GetById(int id);
		Task Add(Class category);
		Task Update(Class category);
		Task Delete(int id);
	}
}
