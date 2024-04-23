using System.ComponentModel.DataAnnotations;

namespace EngLine.Models
{
	public class Level
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; } // A name representing the level of proficiency, e.g. Novice, High, Expert, Conversational, etc.
		[Required]
		public string Code { get; set; } // A two-character symbol for the course’s language level, like A1, C2, NL, D, 2+, etc.
		public List<Course>? Courses { get; set; }
		public bool IsDelete { get; set; }
	}
}
