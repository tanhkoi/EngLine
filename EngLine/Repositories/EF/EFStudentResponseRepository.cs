using System.Reflection.Metadata;
using EngLine.DataAccess;
using EngLine.Models;
using Microsoft.EntityFrameworkCore;

namespace EngLine.Repositories.EF
{
	public class EFStudentResponseRepository : IStudentResponseRepository
	{
		private readonly EngLineContext _context;

		public EFStudentResponseRepository(EngLineContext context)
		{
			_context = context;
		}

		public async Task AddStudentResponseAsync(StudentResponse studentRes)
		{
			_context.StudentResponses.Add(studentRes);
			await _context.SaveChangesAsync();
		}

		public async Task<int> CalculateScore(string studentId, int testId, int responseId)
		{
			var totalScore = await (from sr in _context.StudentResponses
									join a in _context.Answers on sr.Id equals a.StudentResponseId
									join q in _context.Questions on a.QuestionId equals q.Id
									join ao in _context.AnswerOptions on a.SelectedAnswerId equals ao.Id
									where ao.IsCorrectOption == true
									&& sr.StudentId == studentId
									&& sr.TestId == testId
									&& sr.Id == responseId
									select q.Point).SumAsync();

			return totalScore;
		}

		public async Task DeleteStudentResponseAsync(int id)
		{
			var studentResponse = await _context.StudentResponses.FindAsync(id);
			if (studentResponse != null)
			{
				_context.StudentResponses.Remove(studentResponse);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<StudentResponse>> GetAllStudentResponseAsync()
		{
			return await _context.StudentResponses.ToListAsync();
		}

		public async Task<StudentResponse> GetStudentResponseByIdAsync(int id)
		{
			return await _context.StudentResponses.FirstOrDefaultAsync(t => t.Id == id);
		}

		public async Task<decimal?> GetStudentTestScoreAsync(string studentId, int testId)
		{
			var maxScore = await _context.StudentResponses
								 .Where(sr => sr.TestId == testId)
								 .MaxAsync(sr => (decimal?)sr.Score); // Cast to nullable decimal to handle empty results

			return maxScore; // Will return null if no scores are found
		}

		public async Task UpdateStudentResponseAsync(StudentResponse studentRes)
		{
			_context.StudentResponses.Update(studentRes);
			await _context.SaveChangesAsync();
		}
	}
}
