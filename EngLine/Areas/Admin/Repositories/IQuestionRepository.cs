using EngLine.Models;

namespace EngLine.Areas.Admin.Repositories
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetAllQuestionAsync();
        Task<Question> GetQuestionByIdAsync(int id);
        Task AddQuestionAsync(Question quenstion);
        Task UpdateQuestionAsync(Question quenstion);
        Task DeleteQuestionAsync(int id);
    }
}
