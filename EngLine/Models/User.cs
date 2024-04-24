using Microsoft.AspNetCore.Identity;

namespace EngLine.Models
{
	public class User : IdentityUser
	{
        // common fields
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }

        // teacher fields
        public string Description { get; set; }
        public string Photo { get; set; }
        public List<Course>? Courses { get; set; }

        // staff fields
        public string Position { get; set; }

        // student fields
        public DateTime DateBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public List<ClassStudent>? ClassStudents { get; set; }
        public List<Payment>? Payments { get; set; }
	}
}
