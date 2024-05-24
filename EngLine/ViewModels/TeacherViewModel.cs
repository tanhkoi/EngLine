using System.ComponentModel.DataAnnotations;

public class TeacherViewModel
{
	public string Id { get; set; }

	[Required]
	[StringLength(100)]
	public string Username { get; set; }

	[Required]
	[StringLength(100)]
	[EmailAddress]
	public string Email { get; set; }

	[Required]
	[StringLength(50)]
	public string FirstName { get; set; }

	[Required]
	[StringLength(50)]
	public string LastName { get; set; }

	[Required]
	[StringLength(15)]
	[Phone]
	public string PhoneNumber { get; set; }

	[StringLength(500)]
	public string Description { get; set; }

	[StringLength(200)]
	public string Photo { get; set; }

	public bool IsActive { get; set; }
}
