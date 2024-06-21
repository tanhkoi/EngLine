using EngLine.DataAccess;
using EngLine.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EngLine.Repositories.EF
{
	public class EFTestRepository : ITestRepository
	{
		private readonly EngLineContext _context;
		private readonly ILogger<EFTestRepository> _logger;

		public EFTestRepository(EngLineContext context, ILogger<EFTestRepository> logger)
		{
			_context = context;
			_logger = logger;
		}

		public async Task<IEnumerable<Test>> GetAllTestsAsync()
		{
			return await _context.Tests
				.Include(test => test.Teacher)
				.Include(test => test.Questions)
				.ThenInclude(q => q.AnswerOptions)
				.Where(test => !test.IsDelete)
				.ToListAsync();
		}

		public async Task<Test> GetTestByIdAsync(int id)
		{
			var result = await _context.Tests
				.Include(t => t.Teacher)
				.Include(t => t.Questions)
				.ThenInclude(q => q.AnswerOptions)
				.FirstOrDefaultAsync(t => t.Id == id && !t.IsDelete);

			if (result == null)
			{
				_logger.LogWarning("GetTestByIdAsync: Test with ID {TestId} not found", id);
				throw new KeyNotFoundException("Get Test by ID is null");
			}

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
			catch (DbUpdateConcurrencyException ex)
			{
				if (!_context.Tests.Any(e => e.Id == test.Id))
				{
					_logger.LogError(ex, "UpdateTestAsync: Concurrency error when updating test with ID {TestId}", test.Id);
					throw new KeyNotFoundException("Test update not found");
				}
				else
				{
					_logger.LogError(ex, "UpdateTestAsync: Unexpected concurrency error when updating test with ID {TestId}", test.Id);
					throw;
				}
			}
		}

		public async Task DeleteTestAsync(int id)
		{
			var test = await _context.Tests
				.Include(t => t.Teacher)
				.FirstOrDefaultAsync(t => t.Id == id);

			if (test == null)
			{
				_logger.LogWarning("DeleteTestAsync: Test with ID {TestId} not found", id);
				throw new KeyNotFoundException("Test delete not found");
			}

			test.IsDelete = true;
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Test>> GetAllTestByIdTeacherAsync(string id)
		{
			return await _context.Tests
				.Where(c => c.TeacherId == id && !c.IsDelete)
				.Include(t => t.Questions)
				.ThenInclude(q => q.AnswerOptions)
				.ToListAsync();
		}
	}
}
