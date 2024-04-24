using EngLine.Models;

namespace EngLine.Repositories
{
	public interface IAccountRepository
	{
		Task<IEnumerable<User>> GetAll();
		Task<User> GetById(string id);
		Task Add(User user);
		Task Update(User user);
		Task Delete(string id);
	}
}
