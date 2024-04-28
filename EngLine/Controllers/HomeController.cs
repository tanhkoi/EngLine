using EngLine.Models;
using EngLine.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EngLine.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IPaymentRepository _paymentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IClassRepository _classRepository;

        public HomeController(
            ILogger<HomeController> logger,
            IUserRepository userRepository,
            IPaymentRepository paymentRepository,
            ICourseRepository courseRepository,
            IClassRepository classRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
            _paymentRepository = paymentRepository;
            _courseRepository = courseRepository;
            _classRepository = classRepository;
        }

		public IActionResult Index()
		{
			return View();
		}
        public IActionResult About()
        {
            return View();
        }
        public async Task<IActionResult> Course()
        {
            var courses = await _courseRepository.GetAllAsync();

            if (courses == null || !courses.Any())
            {
                ViewBag.IsEmpty = true;
            }
            else
            {
                ViewBag.IsEmpty = false;
            }

            return View(courses);
        }
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
