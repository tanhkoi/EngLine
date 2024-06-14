using EngLine.Models;

namespace EngLine.Repositories
{
	public interface ICertificateRepository
	{
		Task<IEnumerable<Certificate>> GetCertificatesAsync();
		Task AddTeacherCertificateAsync(TeacherCertificate teacherCertificate);

		Task<ICollection<TeacherCertificate>> GetCertificatesByTeacherIdAsync(string teacherId);
		// Add other necessary methods, such as updating or deleting certificates
	}

}
