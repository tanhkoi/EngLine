using EngLine.Models;

namespace EngLine.Repositories
{
	public interface ITestRepository
	{
		Task<IEnumerable<Test>> GetAllTestsAsync();
		Task<IEnumerable<Test>> GetAllTestByIdTeacherAsync(string id);
		Task<Test> GetTestByIdAsync(int id);
		Task AddTestAsync(Test test);
		Task UpdateTestAsync(Test test);
		Task DeleteTestAsync(int id);
	}
}
