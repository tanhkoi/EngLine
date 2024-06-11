namespace EngLine.Models
{
	public class Test
	{
		public int Id { get; set; }
		public string TeacherId { get; set; }
		public string Title { get; set; }
		public decimal TimeLimit { get; set; }

		public Teacher Teacher { get; set; }
		public ICollection<Question> Questions { get; set; }
		public ICollection<StudentResponse> StudentResponses { get; set; }
	}
}
