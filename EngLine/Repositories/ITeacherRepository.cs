using EngLine.Models;

namespace EngLine.Repositories
{
	public interface ITeacherRepository
	{
		Task<IEnumerable<Teacher>> GetAllTeacherAsync();
		Task<Teacher> GetTeacherByIdAsync(string id);
		Task AddTeacherAsync(Teacher teacher);
		Task UpdateTeacherAsync(Teacher teacher);
		Task DeleteTeacherAsync(string id);
	}
}
