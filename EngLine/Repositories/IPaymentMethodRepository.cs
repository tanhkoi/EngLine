using EngLine.Models;

namespace EngLine.Repositories
{
	public interface IPaymentMethodRepository
	{
		Task<IEnumerable<PaymentMethod>> GetAllPaymentMethodAsync();
		Task<PaymentMethod> GetPaymentMethodByIdAsync(int id);
		Task AddPaymentMethodAsync(PaymentMethod paymentMethod);
		Task UpdatePaymentMethodAsync(PaymentMethod paymentMethod);
		Task DeletePaymentMethodAsync(int id);
	}
}
