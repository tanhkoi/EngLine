using EngLine.Models;

namespace EngLine.Repositories
{
	public interface IQuestionRepository
	{
		Task<IEnumerable<Question>> GetAllQuestionAsync();
		Task<Question> GetQuestionByIdAsync(int id);
		Task AddQuestionAsync(Question question);
		Task UpdateQuestionAsync(Question question);
		Task DeleteQuestionAsync(int id);
	}
}
