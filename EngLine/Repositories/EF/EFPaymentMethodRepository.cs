using EngLine.DataAccess;
using EngLine.Models;
using Microsoft.EntityFrameworkCore;

namespace EngLine.Repositories.EF
{
	public class EFPaymentMethodRepository : IPaymentMethodRepository
	{
		private readonly EngLineContext _context;

		public EFPaymentMethodRepository(EngLineContext context)
		{
			_context = context;
		}

        public Task AddPaymentMethodAsync(PaymentMethod paymentMethod)
        {
            throw new NotImplementedException();
        }

        public Task DeletePaymentMethodAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PaymentMethod>> GetAllPaymentMethodAsync()
        {
            return await _context.PaymentMethods.ToListAsync();
        }

        public Task<PaymentMethod> GetPaymentMethodByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePaymentMethodAsync(PaymentMethod paymentMethod)
        {
            throw new NotImplementedException();
        }
    }
}
