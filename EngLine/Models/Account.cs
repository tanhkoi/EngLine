using Microsoft.AspNetCore.Identity;

namespace EngLine.Models
{
	public class Account : IdentityUser
	{
		public bool IsActive { get; }
	}
}
