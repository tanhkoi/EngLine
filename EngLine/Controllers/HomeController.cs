using EngLine.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EngLine.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(
			ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult About()
		{
			return View();
		}

		//public async Task<IActionResult> Courses()
		//{
		//	return View(await _userRepository.GetAllAsyncTeacher());
		//}

		public IActionResult Contact()
		{
			return View();
		}

		public IActionResult CourseDetails()
		{
			return View();
		}

		public IActionResult Elements()
		{
			return View();
		}

		public IActionResult HelloWorld()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
