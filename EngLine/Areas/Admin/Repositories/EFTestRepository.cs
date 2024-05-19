using EngLine.DataAccess;
using EngLine.Models;
using Microsoft.EntityFrameworkCore;

namespace EngLine.Areas.Admin.Repositories
{
	public class EFTestRepository : ITestRepository
	{
		private readonly EngLineContext _context;

		public EFTestRepository(EngLineContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Test>> GetAllTestsAsync()
		{
			return await _context.Tests.ToListAsync();
		}

		public async Task<Test> GetTestByIdAsync(string id)
		{
			var result = await _context.Tests
				.Include(t => t.Questions)
				.ThenInclude(q => q.AnswerOptions)
				.FirstOrDefaultAsync(t => t.Id == id);

			if (result == null)
				throw new KeyNotFoundException("Get Test by ID is null");
			else
				return result;
		}

		public async Task AddTestAsync(Test test)
		{
			_context.Tests.Add(test);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateTestAsync(Test test)
		{
			_context.Entry(test).State = EntityState.Modified;
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!await TestExistsAsync(test.Id))
				{
					throw new KeyNotFoundException("Test update not found");
				}
				else
				{
					throw;
				}
			}
		}

		public async Task DeleteTestAsync(string id)
		{
			if (!string.IsNullOrEmpty(id))
			{
				throw new ArgumentException("Invalid test delete ID");
			}

			var test = await _context.Tests.FindAsync(id);
			if (test == null)
			{
				throw new KeyNotFoundException("Test delete not found");
			}

			_context.Tests.Remove(test);
			await _context.SaveChangesAsync();
		}

		public async Task<bool> TestExistsAsync(string id)
		{
			return await _context.Tests.AnyAsync(t => t.Id == id);
		}
	}
}
