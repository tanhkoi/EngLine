using EngLine.DataAccess;
using EngLine.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EngLine.Repositories
{
	public class EFClassRepository : IClassRepository
	{
		private readonly EngLineContext _context;

		public EFClassRepository(EngLineContext context)
		{
			_context = context;
		}

		public async Task AddAsync(Class @class)
		{
			_context.Classes.Add(@class);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var classToDelete = await _context.Classes.FindAsync(id);
			if (classToDelete != null)
			{
				classToDelete.IsDelete = true;
				_context.Entry(classToDelete).State = EntityState.Modified;
				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<Class>> GetAllAsync()
		{
			return await _context.Classes.ToListAsync();
		}

		public async Task<Class> GetByIdAsync(int id)
		{
			return await _context.Classes.FindAsync(id);
		}

		public async Task UpdateAsync(Class @class)
		{
			_context.Entry(@class).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}
	}
}
