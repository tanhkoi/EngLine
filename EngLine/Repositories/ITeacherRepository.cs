using EngLine.Models;

namespace EngLine.Repositories
{
	public interface ITeacherRepository
	{
		Task<IEnumerable<TeacherAccount>> GetAll();
		Task<TeacherAccount> GetById(string id);
		Task Add(TeacherAccount category);
		Task Update(TeacherAccount category);
		Task Delete(string id);
	}
}
