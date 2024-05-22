using Microsoft.AspNetCore.Mvc;

namespace EngLine.Controllers
{
	public class TestController : Controller
	{
		public IActionResult Reading()
		{
			return View();
		}

		public IActionResult Listening()
		{
			return View();
		}

		public IActionResult Writing()
		{
			return View();
		}
	}
}
