namespace EngLine.Models
{
	public class BookingPayment
	{
		public int Id { get; set; }
		public int PaymentMethodId { get; set; }
		public DateTime PayTime { get; set; }
		public int BookingId { get; set; }

		public PaymentMethod PaymentMethod { get; set; }
		public Booking Booking { get; set; }
	}

}
