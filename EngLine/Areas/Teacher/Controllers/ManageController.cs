using System.Security.Claims;
using EngLine.Models;
using EngLine.Repositories;
using EngLine.Utilitys;
using EngLine.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Area("Teacher")]
[Authorize(Roles = SD.Role_Teacher + "," + SD.Role_Admin)]
public class ManageController : Controller
{
	private readonly ITeacherRepository _teacherRepository;
	private readonly ICourseRepository _courseRepository;

	public ManageController(ITeacherRepository teacherRepository, ICourseRepository courseRepository)
	{
		_teacherRepository = teacherRepository;
		_courseRepository = courseRepository;
	}

	public async Task<IActionResult> Profile()
	{
		var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
		if (id == null)
			return NotFound();
		else
		{
			ViewBag.TeacherCourse = await _courseRepository.GetAllCourseByIdTeacherAsync(id);
			var teacher = await _teacherRepository.GetTeacherByIdAsync(id);
			return View(teacher);
		}
	}

	public async Task<IActionResult> AddCertificates()
	{
		var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
		if (id == null)
			return NotFound();
		else
		{
			var teacher = await _teacherRepository.GetTeacherByIdAsync(id);
			return View(teacher);
		}
	}

	public IActionResult AddCourse()
	{
		ViewBag.TeacherId = User.FindFirstValue(ClaimTypes.NameIdentifier);
		return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> AddCourse(CreateCourseViewModel model)
	{
		if (ModelState.IsValid)
		{
			var course = new Course
			{
				TeacherId = model.TeacherId,
				Price = model.Price,
				Description = model.Description,
				CourseName = model.CourseName,
				CoverPhoto = model.CoverPhoto,
				Lessons = model.Lessons.Select(l => new Lesson
				{
					Name = l.Name,
					Description = l.Description,
					Photo = l.Photo,
					Video = l.Video,
					Content = l.Content
				}).ToList()
			};
			await _courseRepository.AddCourseAsync(course);
			return RedirectToAction(nameof(Profile));
		}
		return View(model);
	}
}
