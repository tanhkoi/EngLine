namespace EngLine.ViewModels
{
	public class TestDetailsViewModel
	{
		public string TestTitle { get; set; }
		public IEnumerable<QuestionViewModel> Questions { get; set; }
	}
}
