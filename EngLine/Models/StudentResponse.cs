namespace EngLine.Models
{
	public class StudentResponse
	{
		public string Id { get; set; }
		public string StudentId { get; set; }
		public string TestId { get; set; }
		public decimal Score { get; set; }

		public Student Student { get; set; }
		public Test Test { get; set; }
		public ICollection<Answer> Answers { get; set; }
	}

}
