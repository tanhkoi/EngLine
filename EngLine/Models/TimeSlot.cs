namespace EngLine.Models
{
	public class TimeSlot
	{
		public int Id { get; set; }
		public int TutorLessonId { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }

		public TutorLesson TutorLesson { get; set; }
		public ICollection<Booking> Bookings { get; set; }
	}

}
