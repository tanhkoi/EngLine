namespace EngLine.Models
{
	public class Question
	{
		public string Id { get; set; }
		public string Content { get; set; }
		public string TestId { get; set; }

		public Test Test { get; set; }
		public ICollection<AnswerOption> AnswerOptions { get; set; }
	}

}
