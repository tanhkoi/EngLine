namespace EngLine.Models
{
	public class TutorLesson
	{
		public int Id { get; set; }
		public string TeacherId { get; set; }
		public decimal MinScore { get; set; }
		public decimal MaxScore { get; set; }
		public decimal Price { get; set; }

		public Teacher Teacher { get; set; }
		public ICollection<TimeSlot> TimeSlots { get; set; }
	}

}
