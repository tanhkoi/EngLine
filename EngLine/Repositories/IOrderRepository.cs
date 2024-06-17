using EngLine.Models;

namespace EngLine.Repositories
{
	public interface IOrderRepository
	{
		Task<IEnumerable<Order>> GetAllOrderAsync();
		Task<Order> GetOrderByIdAsync(int id);
		Task AddOrderAsync(Order order);
		Task UpdateOrderAsync(Order order);
		Task DeleteOrderAsync(int id);
		Task<bool> IsBought(string studentId, int courseId);
	}
}
