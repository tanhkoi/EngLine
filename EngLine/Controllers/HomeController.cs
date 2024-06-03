using EngLine.Models;
using EngLine.Repositories;
using EngLine.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace EngLine.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ICourseRepository _courseRepository;
		private readonly IStudentRepository _studentRepository;
		private readonly IOrderRepository _orderRepository;
		private readonly ITeacherRepository _teacherRepository;

		public HomeController(
			ILogger<HomeController> logger,
			ICourseRepository courseRepository,
			IStudentRepository studentRepository,
			IOrderRepository orderRepository,
			ITeacherRepository teacherRepository
		)
		{
			_logger = logger;
			_courseRepository = courseRepository;
			_studentRepository = studentRepository;
			_orderRepository = orderRepository;
			_teacherRepository = teacherRepository;
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
			if (course == null)
			{
				return NotFound();
			}

			ViewBag.Lessons = course.Lessons;

			ViewBag.isBought = await _orderRepository.isBought(User.FindFirstValue(ClaimTypes.NameIdentifier), id);

			ViewBag.Teacher = await _teacherRepository.GetTeacherByIdAsync(course.TeacherId);

			ViewBag.OrderSuccessMessage = TempData["OrderSuccessMessage"] as string;

			return View(course);
		}

		public async Task<IActionResult> Study(int courseId)
		{
			var course = await _courseRepository.GetCourseByIdAsync(courseId);

			if (course == null)
			{
				return NotFound();
			}

			ViewBag.Teacher = await _teacherRepository.GetTeacherByIdAsync(course.TeacherId);

			var viewModel = new CourseViewModel
			{
				CourseId = course.Id,
				CourseName = course.CourseName,
				Description = course.Description,
				CoverPhoto = course.CoverPhoto,
				Lessons = course.Lessons.Select(l => new LessonViewModel
				{
					LessonId = l.Id,
					Name = l.Name,
					Description = l.Description,
					Photo = l.Photo,
					Video = l.Video,
					Content = l.Content
				}).ToList()
			};

			return View(viewModel);
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