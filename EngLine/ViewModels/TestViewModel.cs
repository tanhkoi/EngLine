using EngLine.Models;

namespace EngLine.ViewModels
{
	public class TestViewModel
	{
		public Test Test { get; set; }
		public List<Question> Questions { get; set; }
		public int CourseId { get; set; }
	}
}
