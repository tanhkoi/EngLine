using EngLine.DataAccess;
using EngLine.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EngLine.Repositories
{
	public class EFUserRepository : IUserRepository
	{
		private readonly EngLineContext _context;

		public EFUserRepository(EngLineContext context)
		{
			_context = context;
		}

		public async Task AddAsync(User user)
		{
			_context.Users.Add(user);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(string id)
		{
			var userToDelete = await _context.Users.FindAsync(id);
			if (userToDelete != null)
			{
				userToDelete.IsActive = false;
				_context.Entry(userToDelete).State = EntityState.Modified;
				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<User>> GetAllAsync()
		{
			return await _context.Users.ToListAsync();
		}

		public async Task<User> GetByIdAsync(string id)
		{
			return await _context.Users.FindAsync(id);
		}

		public async Task UpdateAsync(User user)
		{
			_context.Entry(user).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}
	}
}