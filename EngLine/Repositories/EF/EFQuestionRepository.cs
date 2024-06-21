using EngLine.DataAccess;
using EngLine.Models;
using Microsoft.EntityFrameworkCore;

namespace EngLine.Repositories.EF
{
	public class EFQuestionRepository : IQuestionRepository
	{
		private readonly EngLineContext _context;

		public EFQuestionRepository(EngLineContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Question>> GetAllQuestionAsync()
		{
			var engLineContext = _context.Questions.Include(q => q.Test);
			return await engLineContext.ToListAsync();
		}

		public async Task<Question> GetQuestionByIdAsync(int id)
		{
			var question = await _context.Questions
				.Include(q => q.Test)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (question == null)
			{
				return null;
			}
			return question;
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

		public async Task DeleteQuestionsByTestIdAsync(int testId)
		{
			var questions = _context.Questions.Where(q => q.TestId == testId).ToList();

			_context.Questions.RemoveRange(questions);

			await _context.SaveChangesAsync();
		}
	}
}
