namespace EngLine.Models
{
	public class OrderPayment
	{
		public string Id { get; set; }
		public string PaymentMethodId { get; set; }
		public DateTime PayTime { get; set; }
		public string OrderId { get; set; }

		public PaymentMethod PaymentMethod { get; set; }
		public Order Order { get; set; }
	}

}
