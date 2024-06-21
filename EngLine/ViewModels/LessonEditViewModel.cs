using EngLine.Models;

namespace EngLine.ViewModels
{
	public class LessonEditViewModel
	{
		public int Id { get; set; }
		public int CourseId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string? Photo { get; set; }
		public string? Video { get; set; }
		public string Content { get; set; }
		public bool IsDeleted { get; set; }

		public Course Course { get; set; }
	}
}
