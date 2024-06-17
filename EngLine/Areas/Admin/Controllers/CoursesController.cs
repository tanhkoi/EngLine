using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EngLine.DataAccess;
using EngLine.Models;
using EngLine.ViewModels;
using Microsoft.AspNetCore.Authorization;
using EngLine.Utilitys;
using EngLine.Repositories;
using EngLine.Repositories.EF;
using System.Security.Claims;

namespace EngLine.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = SD.Role_Admin + "," + SD.Role_Teacher)]
	public class CoursesController : Controller
	{
		private readonly ICourseRepository _courseRepository;
		private readonly ITeacherRepository _teacherRepository;
		private readonly ITestRepository _testRepository;

		public CoursesController(ICourseRepository courseRepository,
			ITeacherRepository teacherRepository,
			ITestRepository testRepository)
		{
			_courseRepository = courseRepository;
			_teacherRepository = teacherRepository;
			_testRepository = testRepository;
		}

		// GET: Admin/Courses
		public async Task<IActionResult> Index()
		{
			return View(await _courseRepository.GetAllCoursesAsync());
		}

		// GET: Admin/Courses/Details/5
		public async Task<IActionResult> Details(int id)
		{
			var course = await _courseRepository.GetCourseByIdAsync(id);
			if (course == null)
			{
				return NotFound();
			}

			return View(course);
		}

		// GET: Admin/Courses/Create
		public async Task<IActionResult> CreateAsync()
		{
			var teachers = await _teacherRepository.GetAllTeacherAsync();
			ViewData["TeacherId"] = new SelectList(teachers, "Id", "Id");
			return View();
		}

		// POST: Admin/Courses/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CreateCourseViewModel model)
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
				return RedirectToAction(nameof(Index));
			}
			return View(model);
		}


		// GET: Admin/Courses/Edit/5
		public async Task<IActionResult> Edit(int id)
		{
			var course = await _courseRepository.GetCourseByIdAsync(id);
			if (course == null)
			{
				return NotFound();
			}

			var teachers = await _teacherRepository.GetAllTeacherAsync();
			ViewData["TeacherId"] = new SelectList(teachers, "Id", "Id", course.TeacherId);
			ViewBag.TeacherId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			ViewBag.Test = await _testRepository.GetAllTestsAsync();
			return View(course);
		}

		// POST: Admin/Courses/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, Course course)
		{
			if (id != course.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					await _courseRepository.UpdateCourseAsync(course);
				}
				catch (DbUpdateConcurrencyException)
				{
					var isExist = await _courseRepository.GetCourseByIdAsync(id);
					if (isExist == null)
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			var teachers = await _teacherRepository.GetAllTeacherAsync();

			ViewData["TeacherId"] = new SelectList(teachers, "Id", "Id", course.TeacherId);
			return View(course);
		}

		// GET: Admin/Courses/Delete/5
		public async Task<IActionResult> Delete(int id)
		{
			var course = await _courseRepository.GetCourseByIdAsync(id);
			if (course == null)
			{
				return NotFound();
			}

			return View(course);
		}

		// POST: Admin/Courses/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var course = await _courseRepository.GetCourseByIdAsync(id);
			if (course != null)
			{
				await _courseRepository.DeleteCourseAsync(id);
			}

			return RedirectToAction(nameof(Index));
		}
	}
}
