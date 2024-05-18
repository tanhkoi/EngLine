using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Identity;

namespace EngLine.Models
{
	public class Student : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public bool IsActive { get; set; }

		public ICollection<StudentResponse> StudentResponses { get; set; }
		public ICollection<Booking> Bookings { get; set; }
		public ICollection<Order> Orders { get; set; }
	}

}
