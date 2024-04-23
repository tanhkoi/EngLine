using System.ComponentModel.DataAnnotations;

namespace EngLine.Models
{
	public class StudentAccount : Account
	{
		public DateTime DateBirth { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }
		public List<ClassStudent>? ClassStudents { get; set; }
		public List<Payment>? Payments { get; set; }
	}
}
