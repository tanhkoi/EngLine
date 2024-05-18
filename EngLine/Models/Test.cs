namespace EngLine.Models
{
	public class Test
	{
		public string Id { get; set; }
		public string Title { get; set; }

		public ICollection<Question> Questions { get; set; }
		public ICollection<StudentResponse> StudentResponses { get; set; }
	}

}
