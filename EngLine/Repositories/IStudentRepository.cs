using EngLine.Models;

namespace EngLine.Repositories
{
	public interface IStudentRepository
	{
		Task<IEnumerable<StudentAccount>> GetAll();
		Task<StudentAccount> GetById(int id);
		Task Add(StudentAccount category);
		Task Update(StudentAccount category);
		Task Delete(int id);
	}
}
