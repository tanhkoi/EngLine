using EngLine.Models;

namespace EngLine.Repositories
{
	public interface IPaymentRepository
	{
		Task<IEnumerable<Payment>> GetAll();
		Task<Payment> GetById(int id);
		Task Add(Payment category);
		Task Update(Payment category);
		Task Delete(int id);
	}
}
