using EngLine.Models;

namespace EngLine.Repositories
{
	public interface IAnswerRepository
	{
		Task<IEnumerable<Answer>> GetAllAnswerAsync();
		Task<Answer> GetAnswerByIdAsync(int id);
		Task AddAnswerAsync(Answer answer);
		Task UpdateAnswerAsync(Answer answer);
		Task DeleteAnswerAsync(int id);
	}
}
