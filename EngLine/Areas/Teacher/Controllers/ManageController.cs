using System.Security.Claims;
using EngLine.Models;
using EngLine.Repositories;
using EngLine.Repositories.EF;
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
	private readonly ITestRepository _testRepository;
	private readonly CloudinaryService _cloudinaryService;

	public ManageController(
		ITeacherRepository teacherRepository,
		ICourseRepository courseRepository,
		ITestRepository testRepository,
		CloudinaryService cloudinaryService)
	{
		_teacherRepository = teacherRepository;
		_courseRepository = courseRepository;
		_testRepository = testRepository;
		_cloudinaryService = cloudinaryService;
	}

	public async Task<IActionResult> Profile()
	{
		var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
		if (id == null)
			return NotFound();

		ViewBag.TeacherCourse = await _courseRepository.GetAllCourseByIdTeacherAsync(id);
		ViewBag.TeacherTest = await _testRepository.GetAllTestByIdTeacherAsync(id);

		var teacher = await _teacherRepository.GetTeacherByIdAsync(id);

		return View(teacher);
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

	public async Task<IActionResult> AddCourse()
	{
		ViewBag.TeacherId = User.FindFirstValue(ClaimTypes.NameIdentifier);
		ViewBag.Test = await _testRepository.GetAllTestsAsync();
		return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> AddCourse(CreateCourseViewModel model, IFormFile coverPhotoFile, IFormFile[] lessonPhotoFiles, IFormFile[] lessonVideoFiles)
	{
		var course = new Course
		{
			TeacherId = model.TeacherId,
			TestId = model.TestId,
			Price = model.Price,
			Description = model.Description,
			MinScore = model.MinScore,
			CourseName = model.CourseName,
			CoverPhoto = null, // Placeholder
			Lessons = model.Lessons.Select(lesson => new Lesson
			{
				Name = lesson.Name,
				Description = lesson.Description,
				Photo = null, // Placeholder
				Video = null, // Placeholder
				Content = lesson.Content
			}).ToList()
		};

		string coverPhotoUrl = null;
		if (coverPhotoFile != null)
		{
			coverPhotoUrl = _cloudinaryService.UploadImageAsync(coverPhotoFile);
			course.CoverPhoto = coverPhotoUrl;
		}

		int index = 0;
		foreach (var lesson in course.Lessons)
		{
			if (lessonPhotoFiles.Length > index && lessonPhotoFiles[index] != null)
			{
				lesson.Photo = _cloudinaryService.UploadImageAsync(lessonPhotoFiles[index]);
			}
			if (lessonVideoFiles.Length > index && lessonVideoFiles[index] != null)
			{
				lesson.Video = _cloudinaryService.UploadVideoAsync(lessonVideoFiles[index]);
			}
			index++;
		}

		await _courseRepository.AddCourseAsync(course);
		return RedirectToAction(nameof(Profile));
	}


	public IActionResult AddTest()
	{
		ViewBag.TeacherId = User.FindFirstValue(ClaimTypes.NameIdentifier);
		return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> AddTest(TestEditViewModel viewModel)
	{
		if (ModelState.IsValid)
		{
			var test = new Test
			{
				Title = viewModel.Title,
				TeacherId = User.FindFirstValue(ClaimTypes.NameIdentifier),
				TimeLimit = viewModel.TimeLimit,
				Questions = viewModel.Questions.Select(q => new Question
				{
					Content = q.Content,
					Point = q.Point,
					AnswerOptions = q.AnswerOptions.Select(ao => new AnswerOption
					{
						Content = ao.Content,
						IsCorrectOption = ao.IsCorrectOption
					}).ToList()
				}).ToList()
			};

			await _testRepository.AddTestAsync(test);
			return RedirectToAction(nameof(Profile));
		}
		return View(viewModel);
	}
}
