using EngLine.DataAccess;
using EngLine.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EngLine.Repositories.EF
{
	public class EFOrderRepository : IOrderRepository
	{
		private readonly EngLineContext _context;

		public EFOrderRepository(EngLineContext context)
		{
			_context = context;
		}

		public async Task AddOrderAsync(Order order)
		{
			await _context.Orders.AddAsync(order);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteOrderAsync(int id)
		{
			var order = await _context.Orders.FindAsync(id);
			if (order != null)
			{
				_context.Orders.Remove(order);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<Order>> GetAllOrderAsync()
		{
			return await _context.Orders
				.Include(o => o.Course)
				.Where(o => !o.Course.IsDelete)
				.ToListAsync();
		}

		public async Task<Order> GetOrderByIdAsync(int id)
		{
			return await _context.Orders
				.Include(o => o.Course)
				.FirstOrDefaultAsync(o => o.Id == id && !o.Course.IsDelete);
		}


		public async Task<bool> isBought(string studentId, int courseId)
		{
			var order = await _context.Orders
									.FirstOrDefaultAsync(o => o.StudentId == studentId
									&& o.CourseId == courseId && o.Status == "Success");
			return order != null;
		}


		public async Task UpdateOrderAsync(Order order)
		{
			_context.Orders.Update(order);
			await _context.SaveChangesAsync();
		}
	}
}
