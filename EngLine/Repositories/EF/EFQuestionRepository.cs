using EngLine.DataAccess;
using EngLine.Models;

namespace EngLine.Repositories.EF
{
	public class EFQuestionRepository : IQuestionRepository
	{
		private readonly EngLineContext _context;

		public EFQuestionRepository(EngLineContext context)
		{
			_context = context;
		}

		public Task<IEnumerable<Question>> GetAllQuestionAsync()
		{
			throw new NotImplementedException();
		}

		public Task<Question> GetQuestionByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task AddQuestionAsync(Question question)
		{
			throw new NotImplementedException();
		}

		public async Task DeleteQuestionAsync(int id)
		{
			var question = await _context.Questions.FindAsync(id);
			if (question == null)
			{
				throw new KeyNotFoundException("Question delete not found");
			}

			_context.Questions.Remove(question);
			await _context.SaveChangesAsync();
		}

		public Task UpdateQuestionAsync(Question question)
		{
			throw new NotImplementedException();
		}
	}
}
