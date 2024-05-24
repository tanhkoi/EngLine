using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EngLine.Models;
using EngLine.Repositories;
using EngLine.Utilitys;
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
			var teachers = await _teacherRepository.GetAllTeacherAsync();

			var teacherViewModels = teachers.Select(t => new TeacherViewModel
			{
				Id = t.Id,
				Username = t.UserName,
				Email = t.Email,
				FirstName = t.FirstName,
				LastName = t.LastName,
				PhoneNumber = t.PhoneNumber,
				Description = t.Description,
				Photo = t.Photo,
				IsActive = t.IsActive
			}).ToList();

			return View(teacherViewModels);
		}

		// GET: Teacher/Teacher/Details/5
		public async Task<IActionResult> Details(string? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var teacher = await _teacherRepository.GetTeacherByIdAsync(id);
			if (teacher == null)
			{
				return NotFound();
			}

			var teacherViewModel = new TeacherViewModel
			{
				Id = teacher.Id,
				Username = teacher.UserName,
				Email = teacher.Email,
				FirstName = teacher.FirstName,
				LastName = teacher.LastName,
				PhoneNumber = teacher.PhoneNumber,
				Description = teacher.Description,
				Photo = teacher.Photo,
				IsActive = teacher.IsActive
			};

			return View(teacherViewModel);
		}


		// GET: Teacher/Teacher/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Teacher/Teacher/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(TeacherViewModel model)
		{
			if (ModelState.IsValid)
			{
				var teacher = new Teacher
				{
					Id = model.Id,
					UserName = model.Username,
					Email = model.Email,
					FirstName = model.FirstName,
					LastName = model.LastName,
					PhoneNumber = model.PhoneNumber,
					Description = model.Description,
					Photo = model.Photo,
					IsActive = model.IsActive
				};

				await _teacherRepository.AddTeacherAsync(teacher);
				return RedirectToAction(nameof(Index));
			}
			return View(model);
		}


		// GET: Teacher/Teacher/Edit/5
		public async Task<IActionResult> Edit(string? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var teacher = await _teacherRepository.GetTeacherByIdAsync(id);
			if (teacher == null)
			{
				return NotFound();
			}

			var teacherViewModel = new TeacherViewModel
			{
				Id = teacher.Id,
				Username = teacher.UserName,
				Email = teacher.Email,
				FirstName = teacher.FirstName,
				LastName = teacher.LastName,
				PhoneNumber = teacher.PhoneNumber,
				Description = teacher.Description,
				Photo = teacher.Photo,
				IsActive = teacher.IsActive
			};

			return View(teacherViewModel);
		}


		// POST: Teacher/Teacher/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(string id, TeacherViewModel model)
		{
			if (id != model.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					var teacher = new Teacher
					{
						Id = model.Id,
						UserName = model.Username,
						Email = model.Email,
						FirstName = model.FirstName,
						LastName = model.LastName,
						PhoneNumber = model.PhoneNumber,
						Description = model.Description,
						Photo = model.Photo,
						IsActive = model.IsActive
					};

					await _teacherRepository.UpdateTeacherAsync(teacher);
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
		public async Task<IActionResult> Delete(string? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var teacher = await _teacherRepository.GetTeacherByIdAsync(id);
			if (teacher == null)
			{
				return NotFound();
			}

			return View(teacher);
		}

		// POST: Teacher/Teacher/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(string id)
		{
			await _teacherRepository.DeleteTeacherAsync(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
