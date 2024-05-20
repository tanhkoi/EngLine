namespace EngLine.Models
{
	public class Certificate
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public ICollection<TeacherCertificate> TeacherCertificates { get; set; }
	}

}
