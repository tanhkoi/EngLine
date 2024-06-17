using EngLine.Models;
using EngLine.Repositories;
using EngLine.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace EngLine.Controllers
{
	public class HomeController : Controller
	{
		private readonly ICourseRepository _courseRepository;
		private readonly IStudentRepository _studentRepository;
		private readonly IOrderRepository _orderRepository;
		private readonly ITeacherRepository _teacherRepository;
		private readonly IStudentResponseRepository _studentResponseService;

		public HomeController(ICourseRepository courseRepository,
			IStudentRepository studentRepository,
			IOrderRepository orderRepository,
			ITeacherRepository teacherRepository,
			IStudentResponseRepository studentResponseService)
		{
			_courseRepository = courseRepository;
			_studentRepository = studentRepository;
			_orderRepository = orderRepository;
			_teacherRepository = teacherRepository;
			_studentResponseService = studentResponseService;
		}

		public async Task<IActionResult> Index()
		{
			ViewBag.PopularCourses = await _courseRepository.GetPopularCoursesAsync();
			return View();
		}

		public IActionResult About()
		{
			return View();
		}

		[Authorize]
		public async Task<IActionResult> Courses()
		{
			var courses = await _courseRepository.GetAllCoursesAsync();
			return View(courses);
		}

		public IActionResult Contact()
		{
			return View();
		}

		[Authorize]
		public async Task<IActionResult> CourseDetails(int id)
		{
			var course = await _courseRepository.GetCourseByIdAsync(id);
			if (course == null)
			{
				return NotFound();
			}

			var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

			// Assign course lessons to ViewBag
			ViewBag.Lessons = course.Lessons;

			// Check if the user has bought the course
			ViewBag.isBought = await _orderRepository.IsBought(userId, id);

			// Retrieve teacher details and assign to ViewBag
			ViewBag.Teacher = await _teacherRepository.GetTeacherByIdAsync(course.TeacherId);

			// Retrieve order success message from TempData if available
			ViewBag.OrderSuccessMessage = TempData["OrderSuccessMessage"] as string;

			// Initialize ViewBag property for test taken status
			ViewBag.IsTakenTestThisCourse = false;

			// Pass MinScore to the view
			ViewBag.MinScore = course.MinScore;

			// Check if the course has a test and the user has taken it
			if (course.TestId != null && course.TestId > 0)
			{
				var score = await _studentResponseService.GetStudentTestScoreAsync(userId, course.TestId);
				ViewBag.IsTakenTestThisCourse = true;
				ViewBag.Score = score.Value;
			}

			return View(course);
		}


		[Authorize]
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