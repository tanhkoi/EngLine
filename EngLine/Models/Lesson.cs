namespace EngLine.Models
{
	public class Lesson
	{
		public string Id { get; set; }
		public string CourseId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string? Photo { get; set; }
		public string? Video { get; set; }
		public string Content { get; set; }

		public Course Course { get; set; }
	}

}
