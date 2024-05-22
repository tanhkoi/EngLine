using EngLine.DataAccess;
using EngLine.Models;
using Microsoft.EntityFrameworkCore;

namespace EngLine.Repositories.EF
{
	public class EFTeacherRepository : ITeacherRepository
	{
		private readonly EngLineContext _context;

		public EFTeacherRepository(EngLineContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Teacher>> GetAllTeacherAsync()
		{
			return await _context.Teachers.ToListAsync();
		}
		public async Task<Teacher> GetTeacherByIdAsync(string id)
		{
			return await _context.Teachers.FirstOrDefaultAsync(t => t.Id == id);
		}

		public async Task AddTeacherAsync(Teacher teacher)
		{
			_context.Teachers.Add(teacher);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateTeacherAsync(Teacher teacher)
		{
			_context.Entry(teacher).State = EntityState.Modified;
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (teacher.Id != null)
				{
					throw new KeyNotFoundException("Teacher update not found");
				}
				else
				{
					throw;
				}
			}
		}

		public async Task DeleteTeacherAsync(string id)
		{
			var teacher = await _context.Teachers.FindAsync(id);
			if (teacher == null)
			{
				throw new KeyNotFoundException("Teacher delete not found");
			}

			_context.Teachers.Remove(teacher);
			await _context.SaveChangesAsync();
		}
	}
}
