using CloudinaryDotNet.Actions;

namespace EngLine.Models
{
	public class Course
	{
		public int Id { get; set; }
		public string TeacherId { get; set; }
		public int TestId { get; set; }
		public string CourseName { get; set; }
		public string CoverPhoto { get; set; }
		public decimal Price { get; set; }
		public string Description { get; set; }
		public decimal MinScore { get; set; }
		public bool IsDelete { get; set; }

		public Teacher Teacher { get; set; }
		public Test Test { get; set; }
		public ICollection<Lesson> Lessons { get; set; }
		public ICollection<Order> Orders { get; set; }
	}

}
