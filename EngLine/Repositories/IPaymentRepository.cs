using EngLine.Models;

namespace EngLine.Repositories
{
	public interface IPaymentRepository
	{
		Task<IEnumerable<Payment>> GetAllAsync();
		Task<Payment> GetByIdAsync(int id);
		Task AddAsync(Payment category);
		Task UpdateAsync(Payment category);
		Task DeleteAsync(int id);
	}
}
