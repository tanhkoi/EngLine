using EngLine.DataAccess;
using EngLine.Models;
using EngLine.Utilitys;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EngLine.Repositories.EF
{
	public class EFTeacherRepository : ITeacherRepository
	{
		private readonly EngLineContext _context;
		private readonly UserManager<ApplicationUser> _userManager;

		public EFTeacherRepository(EngLineContext context, UserManager<ApplicationUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		public async Task<IEnumerable<Teacher>> GetAllTeacherAsync()
		{
			return await _context.Teachers.Where(t => t.IsActive).ToListAsync();
		}

		public async Task<Teacher> GetTeacherByIdAsync(string id)
		{
			return await _context.Teachers.FirstOrDefaultAsync(t => t.Id == id && t.IsActive);
		}

		public async Task AddTeacherAsync(Teacher teacher)
		{
			_context.Teachers.Add(teacher);
			await _context.SaveChangesAsync();
			await _userManager.AddToRoleAsync(teacher, SD.Role_Teacher);
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
				if (!await TeacherExists(teacher.Id))
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

			teacher.IsActive = false;
			_context.Teachers.Update(teacher);
			await _context.SaveChangesAsync();
		}

		private async Task<bool> TeacherExists(string id)
		{
			return await _context.Teachers.AnyAsync(e => e.Id == id);
		}
	}
}
