namespace EngLine.Models
{
	public class OrderPayment
	{
		public int Id { get; set; }
		public int PaymentMethodId { get; set; }
		public DateTime PayTime { get; set; }
		public int OrderId { get; set; }

		public PaymentMethod PaymentMethod { get; set; }
		public Order Order { get; set; }
	}

}
