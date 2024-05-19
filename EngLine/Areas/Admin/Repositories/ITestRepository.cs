using EngLine.Models;

namespace EngLine.Areas.Admin.Repositories
{
	public interface ITestRepository
	{
		Task<IEnumerable<Test>> GetAllTestsAsync();
		Task<Test> GetTestByIdAsync(string id);
		Task AddTestAsync(Test test);
		Task UpdateTestAsync(Test test);
		Task DeleteTestAsync(string id);
		Task<bool> TestExistsAsync(string id);
	}
}
