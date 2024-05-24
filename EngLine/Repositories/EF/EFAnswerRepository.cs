using EngLine.DataAccess;
using EngLine.Models;
using Microsoft.EntityFrameworkCore;

namespace EngLine.Repositories.EF
{
	public class EFAnswerRepository : IAnswerRepository
	{
		private readonly EngLineContext _context;

		public EFAnswerRepository(EngLineContext context)
		{
			_context = context;
		}

		public async Task AddAnswerAsync(Answer answer)
		{
			_context.Answers.Add(answer);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAnswerAsync(int id)
		{
			var answer = await _context.Answers.FindAsync(id);
			if (answer != null)
			{
				_context.Answers.Remove(answer);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<Answer>> GetAllAnswerAsync()
		{
			return await _context.Answers.ToListAsync();
		}

		public async Task<Answer> GetAnswerByIdAsync(int id)
		{
			return await _context.Answers.FindAsync(id);
		}

		public async Task UpdateAnswerAsync(Answer answer)
		{
			_context.Entry(answer).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}
	}
}
