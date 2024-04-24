using EngLine.DataAccess;
using EngLine.Models;
using Microsoft.EntityFrameworkCore;

namespace EngLine.Repositories
{
	public class EFStudentRepository : IStudentRepository
	{
		private readonly EngLineContext _context;

		public EFStudentRepository(EngLineContext context)
		{
			_context = context;
		}

		public async Task Add(StudentAccount student)
		{
			_context.StudentAccounts.Add(student);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(string id)
		{
			var studentToDelete = await _context.StudentAccounts.FindAsync(id);
			if (studentToDelete != null)
			{
				studentToDelete.IsActive = false;
				_context.Entry(studentToDelete).State = EntityState.Modified;
				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<StudentAccount>> GetAll()
		{
			return await _context.StudentAccounts.ToListAsync();
		}

		public async Task<StudentAccount> GetById(string id)
		{
			return await _context.StudentAccounts.FindAsync(id);
		}

		public async Task Update(StudentAccount student)
		{
			_context.Entry(student).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}
	}
}