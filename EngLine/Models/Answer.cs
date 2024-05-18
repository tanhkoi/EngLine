namespace EngLine.Models
{
	public class Answer
	{
		public string Id { get; set; }
		public string QuestionId { get; set; }
		public string Content { get; set; }
		public string SelectedAnswerId { get; set; }
		public string StudentResponseId { get; set; }

		public StudentResponse StudentResponse { get; set; }
	}

}
