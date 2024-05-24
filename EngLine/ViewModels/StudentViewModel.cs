using System.ComponentModel.DataAnnotations;

public class StudentViewModel
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

	public bool IsActive { get; set; }
}
