using System.ComponentModel.DataAnnotations;

namespace EngLine.Models
{
	public class Payment
	{
		public int Id { get; set; }
		[Required]
		public DateTime PaymentDate { get; set; }
		[Required]
		public decimal Amount { get; set; }
		public int? PaymentMethodId { get; set; }
		[Required]
		public string Status { get; set; } // The status of the payment (like “pending”, etc).
		public string? StudentId { get; set; }
		public int? ClassId { get; set; }
		public PaymentMethod? PaymentMethod { get; set; }
		public StudentAccount? Student { get; set; }
		public Class? Class { get; set; }
		public bool IsDelete { get; set; }
	}
}
