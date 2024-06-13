using System.ComponentModel.DataAnnotations;

namespace EngLine.Models
{
	public class TeacherCertificate
	{
		public int Id { get; set; }
		public string TeacherId { get; set; }
		public int CertificateId { get; set; }
		public DateTime DateObtained { get; set; }
		public double Score { get; set; }
		public string Photo { get; set; }

		public Teacher Teacher { get; set; }
		public Certificate Certificate { get; set; }
	}

}
