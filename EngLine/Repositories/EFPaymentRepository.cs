using EngLine.DataAccess;
using EngLine.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EngLine.Repositories
{
	public class EFPaymentRepository : IPaymentRepository
	{
		private readonly EngLineContext _context;

		public EFPaymentRepository(EngLineContext context)
		{
			_context = context;
		}

		public async Task Add(Payment payment)
		{
			_context.Payments.Add(payment);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(int id)
		{
			var paymentToDelete = await _context.Payments.FindAsync(id);
			if (paymentToDelete != null)
			{
				paymentToDelete.IsDelete = true;
				_context.Entry(paymentToDelete).State = EntityState.Modified;
				await _context.SaveChangesAsync();
			}
		}

		public async Task<IEnumerable<Payment>> GetAll()
		{
			return await _context.Payments.ToListAsync();
		}

		public async Task<Payment> GetById(int id)
		{
			return await _context.Payments.FindAsync(id);
		}

		public async Task Update(Payment payment)
		{
			_context.Entry(payment).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}
	}
}
