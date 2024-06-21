using System.ComponentModel.DataAnnotations;

namespace EngLine.Models
{
	public class ClassStudent
	{
		public int Id { get; set; }
		public int? ClassId { get; set; }
		public string? StudentId { get; set; }
		public User? Student { get; set; }
		public Class? Class { get; set; }
	}
}
