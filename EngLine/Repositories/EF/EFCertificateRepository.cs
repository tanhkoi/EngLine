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

		// Implement other necessary methods
	}
}
