namespace EngLine.Models
{
	public class Certificate
	{
		public string Id { get; set; }
		public string Name { get; set; }

		public ICollection<TeacherCertificate> TeacherCertificates { get; set; }
	}

}
