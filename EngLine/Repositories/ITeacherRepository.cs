using EngLine.Models;

namespace EngLine.Repositories
{
	public interface ITeacherRepository
	{
		Task<IEnumerable<TeacherAccount>> GetAll();
		Task<TeacherAccount> GetById(int id);
		Task Add(TeacherAccount category);
		Task Update(TeacherAccount category);
		Task Delete(int id);
	}
}
