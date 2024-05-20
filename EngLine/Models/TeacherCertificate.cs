namespace EngLine.Models
{
	public class TeacherCertificate
	{
		public int Id { get; set; }
		public string TeacherId { get; set; }
		public int CertificateId { get; set; }
		public DateTime DateObtained { get; set; }
		public int Score { get; set; }
		public long Photo { get; set; }

		public Teacher Teacher { get; set; }
		public Certificate Certificate { get; set; }
	}

}
