namespace EngLine.ViewModels
{
	public class QuestionViewModel
	{
		public string QuestionContent { get; set; }
		public IEnumerable<AnswerOptionViewModel> AnswerOptions { get; set; }
	}
}
