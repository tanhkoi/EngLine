namespace EngLine.Models
{
	public class TimeSlot
	{
		public string Id { get; set; }
		public string TutorLessonId { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }

		public TutorLesson TutorLesson { get; set; }
		public ICollection<Booking> Bookings { get; set; }
	}

}
