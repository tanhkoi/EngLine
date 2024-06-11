using EngLine.Models;

namespace EngLine.Repositories
{
	public interface IStudentResponseRepository
	{
		Task<IEnumerable<StudentResponse>> GetAllStudentResponseAsync();
		Task<StudentResponse> GetStudentResponseByIdAsync(int id);
		Task AddStudentResponseAsync(StudentResponse studentRes);
		Task UpdateStudentResponseAsync(StudentResponse studentRes);
		Task DeleteStudentResponseAsync(int id);
		Task<int> CalculateScore(string studentId, int testId, int responseId);
		Task<decimal?> GetStudentTestScoreAsync(string studentId, int testId);
	}
}
