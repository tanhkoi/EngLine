using System.ComponentModel.DataAnnotations;

namespace EngLine.Models
{
	public class Category
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; } // A category name like “children”, “youth”, “adult”, etc.
		public List<Course>? Courses { get; set; }
	}
}
