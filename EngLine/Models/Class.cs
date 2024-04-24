using System.ComponentModel.DataAnnotations;

namespace EngLine.Models
{
	public class Class
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public DateTime StartDate { get; set; } // The date of the first lesson of this class.
		[Required]
		public DateTime EndDate { get; set; } // The date of the last lesson of this class.
		[Required]
		public decimal Price { get; set; }
		public string? TeacherId { get; set; }
		public int? CourseId { get; set; }
		public User? Teacher { get; set; }
		public Course? Course { get; set; }
		public List<ClassStudent>? ClassStudents { get; set; }
		public List<Payment>? Payments { get; set; }
		public bool IsDelete { get; set; }
	}
}
