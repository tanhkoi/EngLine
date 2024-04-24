using EngLine.DataAccess;
using EngLine.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EngLine.Repositories
{
	public class EFTeacherRepository : ITeacherRepository
	{
		private readonly EngLineContext _context;

		public EFTeacherRepository(EngLineContext context)
		{
			_context = context;
		}

		public async Task Add(TeacherAccount teacher)
		{
			_context.TeacherAccounts.Add(teacher);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(string id)
		{
			var teacherToDelete = await _context.TeacherAccounts.FindAsync(id);
			if (teacherToDelete != null)
			{
				teacherToDelete.IsActive = false;
				_context.Entry(teacherToDelete).State = EntityState.Modified;
				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<TeacherAccount>> GetAll()
		{
			return await _context.TeacherAccounts.ToListAsync();
		}

		public async Task<TeacherAccount> GetById(string id)
		{
			return await _context.TeacherAccounts.FindAsync(id);
		}

		public async Task Update(TeacherAccount teacher)
		{
			_context.Entry(teacher).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}
	}
}
