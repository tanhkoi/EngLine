using EngLine.Models;
using EngLine.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EngLine.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class StudentController : Controller
	{
		private readonly IStudentRepository _studentRepository;

		public StudentController(IStudentRepository studentRepository)
		{
			_studentRepository = studentRepository;
		}

		// GET: Student/Student
		public async Task<IActionResult> Index()
		{
			var Students = await _studentRepository.GetAllStudentAsync();

			var StudentViewModels = Students.Select(t => new StudentViewModel
			{
				Id = t.Id,
				Username = t.UserName,
				Email = t.Email,
				FirstName = t.FirstName,
				LastName = t.LastName,
				PhoneNumber = t.PhoneNumber,
				IsActive = t.IsActive
			}).ToList();

			return View(StudentViewModels);
		}

		// GET: Student/Student/Details/5
		public async Task<IActionResult> Details(string? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var Student = await _studentRepository.GetStudentByIdAsync(id);
			if (Student == null)
			{
				return NotFound();
			}

			var StudentViewModel = new StudentViewModel
			{
				Id = Student.Id,
				Username = Student.UserName,
				Email = Student.Email,
				FirstName = Student.FirstName,
				LastName = Student.LastName,
				PhoneNumber = Student.PhoneNumber,
				IsActive = Student.IsActive
			};

			return View(StudentViewModel);
		}


		// GET: Student/Student/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Student/Student/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(StudentViewModel model)
		{
			if (ModelState.IsValid)
			{
				var Student = new Student
				{
					Id = model.Id,
					UserName = model.Username,
					Email = model.Email,
					FirstName = model.FirstName,
					LastName = model.LastName,
					PhoneNumber = model.PhoneNumber,
					IsActive = model.IsActive
				};

				await _studentRepository.AddStudentAsync(Student);
				return RedirectToAction(nameof(Index));
			}
			return View(model);
		}


		// GET: Student/Student/Edit/5
		public async Task<IActionResult> Edit(string? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var Student = await _studentRepository.GetStudentByIdAsync(id);
			if (Student == null)
			{
				return NotFound();
			}

			var StudentViewModel = new StudentViewModel
			{
				Id = Student.Id,
				Username = Student.UserName,
				Email = Student.Email,
				FirstName = Student.FirstName,
				LastName = Student.LastName,
				PhoneNumber = Student.PhoneNumber,
				IsActive = Student.IsActive
			};

			return View(StudentViewModel);
		}


		// POST: Student/Student/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(string id, StudentViewModel model)
		{
			if (id != model.Id)
			{
				return NotFound();
			}

			try
			{
				var StudentToUpdate = await _studentRepository.GetStudentByIdAsync(model.Id);
				StudentToUpdate.Id = model.Id;
				StudentToUpdate.UserName = model.Email;
				StudentToUpdate.Email = model.Email;
				StudentToUpdate.FirstName = model.FirstName;
				StudentToUpdate.LastName = model.LastName;
				StudentToUpdate.PhoneNumber = model.PhoneNumber;
				StudentToUpdate.IsActive = model.IsActive;

				await _studentRepository.UpdateStudentAsync(StudentToUpdate);
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
			}
			return RedirectToAction(nameof(Index));
		}


		// GET: Student/Student/Delete/5
		public async Task<IActionResult> Delete(string? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var Student = await _studentRepository.GetStudentByIdAsync(id);
			if (Student == null)
			{
				return NotFound();
			}

			var StudentViewModel = new StudentViewModel
			{
				Id = Student.Id,
				Username = Student.UserName,
				Email = Student.Email,
				FirstName = Student.FirstName,
				LastName = Student.LastName,
				PhoneNumber = Student.PhoneNumber,
				IsActive = Student.IsActive
			};

			return View(StudentViewModel);
		}

		// POST: Student/Student/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(string id)
		{
			await _studentRepository.DeleteStudentAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
