namespace EngLine.Models
{
	public class TeacherAccount : Account
	{
		public string Description { get; set; }
		public string Photo { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }
		public List<Course>? Courses { get; set; }
	}
}
