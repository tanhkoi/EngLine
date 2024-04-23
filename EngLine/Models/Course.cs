using System.ComponentModel.DataAnnotations;

namespace EngLine.Models
{
	public class Course
	{
		public int Id { get; set; }
		[Required]
		public int Lessons { get; set; } // Denotes the number of lessons in the course.
		[Required]
		public string Description { get; set; } // A short description of the course.
		[Required]
		public string Term { get; set; } // How long the course lasts.
		public int? LevelId { get; set; }
		public int? CategoryId { get; set; }
		public Level? Level { get; set; }
		public Category? Category { get; set; }
		public List<Class>? Classes { get; set; }
		public bool IsDelete { get; set; }
	}
}
