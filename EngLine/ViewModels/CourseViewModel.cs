namespace EngLine.ViewModels
{
	public class CourseViewModel
	{
		public int CourseId { get; set; }
		public string CourseName { get; set; }
		public string Description { get; set; }
		public string CoverPhoto { get; set; }
		public ICollection<LessonViewModel> Lessons { get; set; }
	}
}
