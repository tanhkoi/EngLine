using EngLine.DataAccess;
using EngLine.Models;
using Microsoft.EntityFrameworkCore;

namespace EngLine.Repositories.EF
{
	public class EFStudentRepository : IStudentRepository
	{
		private readonly EngLineContext _context;

		public EFStudentRepository(EngLineContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Student>> GetAllStudentAsync()
		{
			return await _context.Students.ToListAsync();
		}
		public async Task<Student> GetStudentByIdAsync(string id)
		{
			return await _context.Students.FirstOrDefaultAsync(t => t.Id == id);
		}

		public async Task AddStudentAsync(Student student)
		{
			_context.Students.Add(student);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateStudentAsync(Student student)
		{
			_context.Students.Update(student);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteStudentAsync(string id)
		{
			var Student = await _context.Students.FindAsync(id);
			if (Student == null)
			{
				throw new KeyNotFoundException("Student delete not found");
			}

			_context.Students.Remove(Student);
			await _context.SaveChangesAsync();
		}
	}
}