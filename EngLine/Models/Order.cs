namespace EngLine.Models
{
	public class Order
	{
		public int Id { get; set; }
		public string StudentId { get; set; }
		public int CourseId { get; set; }
		public DateTime OrderTime { get; set; }
		public decimal Amount { get; set; }
		public string Status { get; set; }
		public bool IsDeleted { get; set; }

		public Student Student { get; set; }
		public Course Course { get; set; }
	}

}
