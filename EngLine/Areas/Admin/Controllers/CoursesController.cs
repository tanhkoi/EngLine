using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EngLine.DataAccess;
using EngLine.Models;

namespace EngLine.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CoursesController : Controller
	{
		private readonly EngLineContext _context;

		public CoursesController(EngLineContext context)
		{
			_context = context;
		}

		// GET: Admin/Courses
		public async Task<IActionResult> Index()
		{
			var engLineContext = _context.Courses.Include(c => c.Teacher);
			return View(await engLineContext.ToListAsync());
		}

		// GET: Admin/Courses/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var course = await _context.Courses
				.Include(c => c.Teacher)
				.FirstOrDefaultAsync(m => m.Id == id);
			if (course == null)
			{
				return NotFound();
			}

			return View(course);
		}

		// GET: Admin/Courses/Create
		public IActionResult Create()
		{
			ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Id");
			return View();
		}

		// POST: Admin/Courses/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,TeacherId,Price,Description")] Course course)
		{
			if (ModelState.IsValid)
			{
				_context.Add(course);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Id", course.TeacherId);
			return View(course);
		}

		// GET: Admin/Courses/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var course = await _context.Courses.FindAsync(id);
			if (course == null)
			{
				return NotFound();
			}
			ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Id", course.TeacherId);
			return View(course);
		}

		// POST: Admin/Courses/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,TeacherId,Price,Description")] Course course)
		{
			if (id != course.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(course);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!CourseExists(course.Id))
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
			ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Id", course.TeacherId);
			return View(course);
		}

		// GET: Admin/Courses/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var course = await _context.Courses
				.Include(c => c.Teacher)
				.FirstOrDefaultAsync(m => m.Id == id);
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
			var course = await _context.Courses.FindAsync(id);
			if (course != null)
			{
				_context.Courses.Remove(course);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool CourseExists(int id)
		{
			return _context.Courses.Any(e => e.Id == id);
		}
	}
}
