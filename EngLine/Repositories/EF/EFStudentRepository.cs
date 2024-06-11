using EngLine.DataAccess;
using EngLine.Models;
using EngLine.Utilitys;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EngLine.Repositories.EF
{
	public class EFStudentRepository : IStudentRepository
	{
		private readonly EngLineContext _context;
		private readonly UserManager<ApplicationUser> _userManager;

		public EFStudentRepository(EngLineContext context, UserManager<ApplicationUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		public async Task<IEnumerable<Student>> GetAllStudentAsync()
		{
			return await _context.Students.Where(s => s.IsActive).ToListAsync();
		}

		public async Task<Student> GetStudentByIdAsync(string id)
		{
			return await _context.Students.FirstOrDefaultAsync(t => t.Id == id && t.IsActive);
		}

		public async Task AddStudentAsync(Student student)
		{
			_context.Students.Add(student);
			await _context.SaveChangesAsync();
			await _userManager.AddToRoleAsync(student, SD.Role_Student);
		}

		public async Task UpdateStudentAsync(Student student)
		{
			_context.Students.Update(student);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteStudentAsync(string id)
		{
			var student = await _context.Students.FindAsync(id);
			if (student == null)
			{
				throw new KeyNotFoundException("Student delete not found");
			}

			student.IsActive = false;
			_context.Students.Update(student);
			await _context.SaveChangesAsync();
		}
	}
}
