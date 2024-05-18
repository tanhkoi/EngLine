using CloudinaryDotNet.Actions;

namespace EngLine.Models
{
	public class Course
	{
		public string Id { get; set; }
		public string TeacherId { get; set; }
		public decimal Price { get; set; }
		public string Description { get; set; }

		public Teacher Teacher { get; set; }
		public ICollection<Lesson> Lessons { get; set; }
		public ICollection<Order> Orders { get; set; }
	}

}
