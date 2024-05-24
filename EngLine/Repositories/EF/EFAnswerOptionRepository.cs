using EngLine.DataAccess;
using EngLine.Models;
using Microsoft.EntityFrameworkCore;

namespace EngLine.Repositories.EF
{
	public class EFAnswerOptionRepository : IAnswerOptionRepository
	{
		private readonly EngLineContext _context;

		public EFAnswerOptionRepository(EngLineContext context)
		{
			_context = context;
		}

		public async Task AddAnswerOptionAsync(AnswerOption answerOption)
		{
			_context.AnswerOptions.Add(answerOption);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAnswerOptionAsync(int id)
		{
			var answerOption = await _context.AnswerOptions.FindAsync(id);
			if (answerOption != null)
			{
				_context.AnswerOptions.Remove(answerOption);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<AnswerOption>> GetAllAnswerOptionAsync()
		{
			return await _context.AnswerOptions.ToListAsync();
		}

		public async Task<AnswerOption> GetAnswerOptionByIdAsync(int id)
		{
			return await _context.AnswerOptions.FindAsync(id);
		}

		public async Task UpdateAnswerOptionAsync(AnswerOption answerOption)
		{
			_context.Entry(answerOption).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}
	}
}
