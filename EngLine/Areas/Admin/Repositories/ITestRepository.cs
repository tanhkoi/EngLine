using EngLine.Models;

namespace EngLine.Areas.Admin.Repositories
{
	public interface ITestRepository
	{
		Task<IEnumerable<Test>> GetAllTestsAsync();
		Task<Test> GetTestByIdAsync(int id);
		Task AddTestAsync(Test test);
		Task UpdateTestAsync(Test test);
		Task DeleteTestAsync(int id);
	}
}
