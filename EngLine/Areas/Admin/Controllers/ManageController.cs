using EngLine.Utilitys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EngLine.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = SD.Role_Admin + "," + SD.Role_Teacher)]
	public class ManageController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
