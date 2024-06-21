using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Identity;

namespace EngLine.Models
{
	public class Student : ApplicationUser
	{
		public ICollection<StudentResponse> StudentResponses { get; set; }
		public ICollection<Order> Orders { get; set; }
	}

}
