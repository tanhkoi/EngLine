using System.ComponentModel.DataAnnotations;

namespace EngLine.Models
{
	public class PaymentMethod
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; } // The payment method name (i.e. “cash”, “credit card”, “debit card”, etc).
		public List<Payment>? Payments { get; set; }
		public bool IsDelete { get; set; }
	}
}
