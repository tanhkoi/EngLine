namespace EngLine.Models
{
	public class Booking
	{
		public string Id { get; set; }
		public string TimeSlotId { get; set; }
		public string StudentId { get; set; }
		public DateTime BookingTime { get; set; }
		public decimal Amount { get; set; }
		public string Status { get; set; }
		public bool IsDeleted { get; set; }

		public TimeSlot TimeSlot { get; set; }
		public Student Student { get; set; }
	}

}
