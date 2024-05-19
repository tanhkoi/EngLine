using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EngLine.Models;
using EngLine.DataAccess;
using EngLine.Areas.Admin.Repositories;
using EngLine.ViewModels;

namespace EngLine.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class TestController : Controller
	{
		private readonly ITestRepository _testRepository;

		public TestController(ITestRepository testRepository)
		{
			_testRepository = testRepository;
		}
		// GET: TestController
		public ActionResult Index()
		{
			return View();
		}

		// GET: TestController/Details/5
		public async Task<IActionResult> Details(string? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var test = await _testRepository.GetTestByIdAsync(id);
			if (test == null)
			{
				return NotFound();
			}

			var viewModel = new TestDetailsViewModel
			{
				TestTitle = test.Title,
				Questions = test.Questions.Select(q => new QuestionViewModel
				{
					QuestionContent = q.Content,
					AnswerOptions = q.AnswerOptions.Select(a => new AnswerOptionViewModel
					{
						AnswerContent = a.Content,
						IsCorrectOption = a.IsCorrectOption
					}).ToList()
				}).ToList()
			};

			return View(viewModel);
		}

		// GET: TestController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: TestController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: TestController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: TestController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: TestController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: TestController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
