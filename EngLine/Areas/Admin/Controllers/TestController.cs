using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EngLine.Models;
using EngLine.DataAccess;
using EngLine.ViewModels;
using EngLine.Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using EngLine.Utilitys;
using EngLine.Repositories.EF;
using Microsoft.Extensions.Logging;

namespace EngLine.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = SD.Role_Admin + "," + SD.Role_Teacher)]
	public class TestController : Controller
	{
		private readonly ITestRepository _testRepository;
		private readonly IQuestionRepository _questionRepository;
		private readonly IAnswerOptionRepository _answerOptionRepository;
		private readonly ILogger<TestController> _logger;

		public TestController(ITestRepository testRepository,
			IQuestionRepository questionRepository,
			IAnswerOptionRepository answerRepository,
			ILogger<TestController> logger)
		{
			_testRepository = testRepository;
			_questionRepository = questionRepository;
			_answerOptionRepository = answerRepository;
			_logger = logger;
		}

		// GET: Admin/Test
		public async Task<ActionResult> Index()
		{
			var result = await _testRepository.GetAllTestsAsync();
			return View(result);
		}

		// GET: Admin/Test/Details/5
		public async Task<IActionResult> Details(int id)
		{
			var test = await _testRepository.GetTestByIdAsync(id);
			if (test == null)
			{
				_logger.LogWarning("Details: Test with ID {TestId} not found", id);
				return NotFound();
			}

			var viewModel = new TestEditViewModel
			{
				Title = test.Title,
				Questions = test.Questions.Select(q => new QuestionEditViewModel
				{
					Content = q.Content,
					Point = q.Point,
					AnswerOptions = q.AnswerOptions.Select(a => new AnswerOptionEditViewModel
					{
						Content = a.Content,
						IsCorrectOption = a.IsCorrectOption
					}).ToList()
				}).ToList()
			};
			return View(viewModel);
		}

		// GET: Admin/Test/Create
		public IActionResult Create()
		{
			return View(new TestEditViewModel());
		}

		// POST: Admin/Test/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(TestEditViewModel viewModel)
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
				return RedirectToAction(nameof(Index));
			}
			return View(viewModel);
		}

		// GET: Admin/Test/Edit/5
		public async Task<IActionResult> Edit(int id)
		{
			var test = await _testRepository.GetTestByIdAsync(id);

			if (test == null)
			{
				_logger.LogWarning("Edit: Test with ID {TestId} not found", id);
				return NotFound();
			}

			var viewModel = new TestEditViewModel
			{
				Id = test.Id,
				Title = test.Title,
				TimeLimit = test.TimeLimit,
				Questions = test.Questions.Select(q => new QuestionEditViewModel
				{
					Id = q.Id,
					Content = q.Content,
					Point = q.Point,
					AnswerOptions = q.AnswerOptions.Select(a => new AnswerOptionEditViewModel
					{
						Id = a.Id,
						Content = a.Content,
						IsCorrectOption = a.IsCorrectOption
					}).ToList()
				}).ToList()
			};

			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, TestEditViewModel viewModel)
		{
			if (id != viewModel.Id)
			{
				return NotFound();
			}

			var test = await _testRepository.GetTestByIdAsync(id);
			if (test == null)
			{
				return NotFound();
			}

			// Filter out deleted questions
			viewModel.Questions = viewModel.Questions.Where(q => !q.IsDeleted).ToList();

			// For each question, filter out deleted answers
			foreach (var question in viewModel.Questions)
			{
				question.AnswerOptions = question.AnswerOptions.Where(a => !a.IsDeleted).ToList();
			}

			test.Title = viewModel.Title;
			test.TimeLimit = viewModel.TimeLimit;

			// Delete existing questions by test.Id
			await _questionRepository.DeleteQuestionsByTestIdAsync(test.Id);

			// Add or update questions from the viewModel
			test.Questions = viewModel.Questions.Select(q => new Question
			{
				Id = q.Id,
				Content = q.Content,
				Point = q.Point,
				TestId = test.Id,
				AnswerOptions = q.AnswerOptions.Select(a => new AnswerOption
				{
					Id = a.Id,
					Content = a.Content,
					IsCorrectOption = a.IsCorrectOption
				}).ToList()
			}).ToList();

			try
			{
				await _testRepository.UpdateTestAsync(test);
			}
			catch (DbUpdateConcurrencyException ex)
			{
				if (!await TestExists(viewModel.Id))
				{
					_logger.LogError(ex, "Edit: Concurrency error when updating test with ID {TestId}", viewModel.Id);
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return RedirectToAction(nameof(Index));
		}

		// GET: Admin/Test/Delete/5
		public async Task<IActionResult> Delete(int id)
		{
			var test = await _testRepository.GetTestByIdAsync(id);
			if (test == null)
			{
				_logger.LogWarning("Delete: Test with ID {TestId} not found", id);
				return NotFound();
			}

			return View(test);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var test = await _testRepository.GetTestByIdAsync(id);
			if (test != null)
			{
				await _testRepository.DeleteTestAsync(id);
			}

			return RedirectToAction(nameof(Index));
		}

		private async Task<bool> TestExists(int id)
		{
			return await _testRepository.GetTestByIdAsync(id) != null;
		}
	}
}
