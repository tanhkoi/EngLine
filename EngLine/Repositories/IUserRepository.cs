﻿using EngLine.Models;

namespace EngLine.Repositories
{
	public interface IUserRepository
	{
		Task<IEnumerable<User>> GetAllAsync();
		Task<IList<User>> GetAllAsyncTeacher();
		Task<User> GetByIdAsync(string id);
		Task AddAsync(User user);
		Task UpdateAsync(User user);
		Task DeleteAsync(string id);
	}
}
