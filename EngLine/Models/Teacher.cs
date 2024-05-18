using CloudinaryDotNet;
using Microsoft.AspNetCore.Identity;

namespace EngLine.Models
{
	public class Teacher : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Description { get; set; }
		public string? Photo { get; set; }
		public bool IsActive { get; set; }

		public ICollection<TeacherCertificate> TeacherCertificates { get; set; }
		public ICollection<TutorLesson> TutorLessons { get; set; }
		public ICollection<Course> Courses { get; set; }
	}

}
