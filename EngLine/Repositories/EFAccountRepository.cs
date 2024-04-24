using EngLine.DataAccess;
using EngLine.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EngLine.Repositories
{
	public class EFAccountRepository : IAccountRepository
	{
		private readonly EngLineContext _context;

		public EFAccountRepository(EngLineContext context)
		{
			_context = context;
		}

		public async Task Add(User user)
		{
			_context.Users.Add(user);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(string id)
		{
			var userToDelete = await _context.Users.FindAsync(id);
			if (userToDelete != null)
			{
				userToDelete.IsActive = false;
				_context.Entry(userToDelete).State = EntityState.Modified;
				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<User>> GetAll()
		{
			return await _context.Users.ToListAsync();
		}

		public async Task<User> GetById(string id)
		{
			return await _context.Users.FindAsync(id);
		}

		public async Task Update(User user)
		{
			_context.Entry(user).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}
	}
}
