using EngLine.Models;

namespace EngLine.Repositories
{
	public interface ICourseRepository
	{
		Task<IEnumerable<Course>> GetAllCoursesAsync();
		Task<IEnumerable<Course>> GetCoursesByTeacherIdAsync(string teacherId);
		Task<Course> GetCourseByIdAsync(int courseId);
		Task AddCourseAsync(Course newCourse);
		Task UpdateCourseAsync(Course updatedCourse);
		Task DeleteCourseAsync(int courseId);
		Task<IEnumerable<Course>> GetPopularCoursesAsync();
	}
}
