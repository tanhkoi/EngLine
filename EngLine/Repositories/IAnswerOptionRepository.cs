using EngLine.Models;

namespace EngLine.Repositories
{
	public interface IAnswerOptionRepository
	{
		Task<IEnumerable<AnswerOption>> GetAllAnswerOptionAsync();
		Task<AnswerOption> GetAnswerOptionByIdAsync(int id);
		Task AddAnswerOptionAsync(AnswerOption answerOption);
		Task UpdateAnswerOptionAsync(AnswerOption answerOption);
		Task DeleteAnswerOptionAsync(int id);
	}
}
