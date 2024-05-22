using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngLine.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EngLine.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class TeacherController : Controller
	{
		private readonly ITeacherRepository _teacherRepository;

		public TeacherController(ITeacherRepository teacherRepository)
		{
			_teacherRepository = teacherRepository;
		}

		// GET: Teacher/Teacher
		public async Task<IActionResult> Index()
		{
			var teachers = await _teacherRepository.GetAllTeachersAsync();
			return View(teachers);
		}

		// GET: Teacher/Teacher/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var teacher = await _teacherRepository.GetTeacherByIdAsync(id.Value);
			if (teacher == null)
			{
				return NotFound();
			}

			return View(teacher);
		}

		// GET: Teacher/Teacher/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Teacher/Teacher/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Teacher model)
		{
			if (ModelState.IsValid)
			{
				await _teacherRepository.CreateTeacherAsync(model);
				return RedirectToAction(nameof(Index));
			}
			return View(model);
		}

		// GET: Teacher/Teacher/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var teacher = await _teacherRepository.GetTeacherByIdAsync(id.Value);
			if (teacher == null)
			{
				return NotFound();
			}

			return View(teacher);
		}

		// POST: Teacher/Teacher/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, Teacher model)
		{
			if (id != model.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					await _teacherRepository.UpdateTeacherAsync(model);
				}
				catch (Exception ex)
				{
					// Log the exception
					ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
				}
				return RedirectToAction(nameof(Index));
			}
			return View(model);
		}

		// GET: Teacher/Teacher/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var teacher = await _teacherRepository.GetTeacherByIdAsync(id.Value);
			if (teacher == null)
			{
				return NotFound();
			}

			return View(teacher);
		}

		// POST: Teacher/Teacher/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			await _teacherRepository.DeleteTeacherAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
