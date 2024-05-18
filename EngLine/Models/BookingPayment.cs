namespace EngLine.Models
{
	public class BookingPayment
	{
		public string Id { get; set; }
		public string PaymentMethodId { get; set; }
		public DateTime PayTime { get; set; }
		public string BookingId { get; set; }

		public PaymentMethod PaymentMethod { get; set; }
		public Booking Booking { get; set; }
	}

}
