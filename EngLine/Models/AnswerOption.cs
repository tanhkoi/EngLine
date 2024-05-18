namespace EngLine.Models
{
	public class AnswerOption
	{
		public string Id { get; set; }
		public string Content { get; set; }
		public string QuestionId { get; set; }
		public bool IsCorrectOption { get; set; }

		public Question Question { get; set; }
	}

}
