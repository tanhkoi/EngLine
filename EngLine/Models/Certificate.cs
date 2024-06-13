namespace EngLine.Models
{
	public class Certificate
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double ScoreMin { get; set; }
		public double ScoreMax { get; set; }

		public ICollection<TeacherCertificate> TeacherCertificates { get; set; }
	}

}
