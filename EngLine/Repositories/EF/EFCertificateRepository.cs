using EngLine.DataAccess;
using EngLine.Models;
using Microsoft.EntityFrameworkCore;

namespace EngLine.Repositories.EF
{
	public class EFCertificateRepository : ICertificateRepository
	{
		private readonly EngLineContext _context;

		public EFCertificateRepository(EngLineContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Certificate>> GetCertificatesAsync()
		{
			return await _context.Certificates.ToListAsync();
		}

		public async Task AddTeacherCertificateAsync(TeacherCertificate teacherCertificate)
		{
			_context.TeacherCertificates.Add(teacherCertificate);
			await _context.SaveChangesAsync();
		}

		public async Task<ICollection<TeacherCertificate>> GetCertificatesByTeacherIdAsync(string teacherId)
		{
			return await _context.TeacherCertificates
								 .Where(tc => tc.TeacherId == teacherId)
								 .Include(tc => tc.Certificate)
								 .ToListAsync() as ICollection<TeacherCertificate>;
		}


		// Implement other necessary methods
	}
}
