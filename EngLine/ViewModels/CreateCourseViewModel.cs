namespace EngLine.ViewModels
{
	public class CreateCourseViewModel
	{
		public string TeacherId { get; set; }
		public long Price { get; set; }
		public string CourseName { get; set; }
		public string CoverPhoto { get; set; }
		public string Description { get; set; }
		public List<CreateLessonViewModel> Lessons { get; set; } = new List<CreateLessonViewModel>();

	}
}
