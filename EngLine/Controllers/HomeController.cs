using EngLine.Models;
using EngLine.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EngLine.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ICourseRepository _courseRepository;

		public HomeController(
			ILogger<HomeController> logger,
			ICourseRepository courseRepository
			)
		{
			_logger = logger;
			_courseRepository = courseRepository;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult About()
		{
			return View();
		}

		public async Task<IActionResult> Courses()
		{
			var courses = await _courseRepository.GetAllCourseAsync();
			return View(courses);
		}

		public IActionResult Contact()
		{
			return View();
		}

		public async Task<IActionResult> CourseDetails(int id)
		{
			var course = await _courseRepository.GetCourseByIdAsync(id);
			ViewBag.Lessons = course.Lessons;
			return View(course);
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
