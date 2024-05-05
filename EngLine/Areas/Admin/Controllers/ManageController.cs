using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EngLine.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class ManageController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
