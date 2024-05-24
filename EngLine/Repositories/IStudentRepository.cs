using EngLine.Models;

namespace EngLine.Repositories
{
	public interface IStudentRepository
	{
		Task<IEnumerable<Student>> GetAllStudentAsync();
		Task<Student> GetStudentByIdAsync(string id);
		Task AddStudentAsync(Student student);
		Task UpdateStudentAsync(Student student);
		Task DeleteStudentAsync(string id);
	}
}
