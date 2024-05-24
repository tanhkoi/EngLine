using EngLine.Models;

namespace EngLine.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllCourseAsync();
        Task<Course> GetCourseByIdAsync(int id);
        Task AddCourseAsync(Course course);
        Task UpdateCourseAsync(Course course);
        Task DeleteCourseAsync(int id);
    }
}
