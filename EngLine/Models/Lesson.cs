namespace EngLine.Models
{
	public class Lesson
	{
		public int Id { get; set; }
		public int CourseId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string? Photo { get; set; }
		public string? Video { get; set; }
		public string Content { get; set; }

		public Course Course { get; set; }
	}

}
