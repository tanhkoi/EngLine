using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EngLine.Models;
using EngLine.DataAccess;
using EngLine.ViewModels;
using EngLine.Repositories;

namespace EngLine.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class TestController : Controller
	{
		private readonly ITestRepository _testRepository;
		private readonly IQuestionRepository _questionRepository;
		private readonly EngLineContext _context;

		public TestController(ITestRepository testRepository, EngLineContext context, IQuestionRepository questionRepository)
		{
			_testRepository = testRepository;
			_context = context;
			_questionRepository = questionRepository;
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
				return NotFound();
			}

			var viewModel = new TestEditViewModel
			{
				Title = test.Title,
				Questions = test.Questions.Select(q => new QuestionEditViewModel
				{
					Content = q.Content,
					AnswerOptions = q.AnswerOptions.Select(a => new AnswerOptionEditViewModel
					{
						Content = a.Content,
						IsCorrectOption = a.IsCorrectOption
					}).ToList()
				}).ToList()
			};
			return View(viewModel);
		}

		// GET:  Admin/Test/Create
		public IActionResult Create()
		{
			return View(new TestEditViewModel());
		}

		// POST:  Admin/Test/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(TestEditViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var test = new Test
				{
					Title = viewModel.Title,
					TimeLimit = viewModel.TimeLimit,
					Questions = viewModel.Questions.Select(q => new Question
					{
						Content = q.Content,
						AnswerOptions = q.AnswerOptions.Select(ao => new AnswerOption
						{
							Content = ao.Content,
							IsCorrectOption = ao.IsCorrectOption
						}).ToList()
					}).ToList()
				};

				_context.Add(test);
				await _context.SaveChangesAsync();
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

		// POST: Admin/Test/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, TestEditViewModel viewModel)
		{
			if (id != viewModel.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					var test = await _testRepository.GetTestByIdAsync(id);

					if (test == null)
					{
						return NotFound();
					}

					test.Title = viewModel.Title;
					test.TimeLimit = viewModel.TimeLimit;

					foreach (var questionVm in viewModel.Questions)
					{
						Question question;

						if (questionVm.Id == 0)
						{
							question = new Question
							{
								Content = questionVm.Content,
								AnswerOptions = questionVm.AnswerOptions.Select(a => new AnswerOption
								{
									Content = a.Content,
									IsCorrectOption = a.IsCorrectOption
								}).ToList()
							};
							test.Questions.Add(question);
						}
						else
						{
							question = test.Questions.FirstOrDefault(q => q.Id == questionVm.Id);
							if (questionVm.IsDeleted)
							{
								if (question != null)
								{
									_context.Questions.Remove(question);
								}
							}
							else
							{
								if (question != null)
								{
									question.Content = questionVm.Content;

									foreach (var answerOptionVm in questionVm.AnswerOptions)
									{
										AnswerOption answerOption;

										if (answerOptionVm.Id == 0)
										{
											answerOption = new AnswerOption
											{
												Content = answerOptionVm.Content,
												IsCorrectOption = answerOptionVm.IsCorrectOption
											};
											question.AnswerOptions.Add(answerOption);
										}
										else
										{
											answerOption = question.AnswerOptions.FirstOrDefault(a => a.Id == answerOptionVm.Id);
											if (answerOptionVm.IsDeleted)
											{
												if (answerOption != null)
												{
													_context.AnswerOptions.Remove(answerOption);
												}
											}
											else
											{
												if (answerOption != null)
												{
													answerOption.Content = answerOptionVm.Content;
													answerOption.IsCorrectOption = answerOptionVm.IsCorrectOption;
												}
											}
										}
									}
								}
							}
						}
					}
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!TestExists(viewModel.Id))
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
			return View(viewModel);
		}

		// GET: Admin/Test/Delete/5
		public async Task<ActionResult> Delete(int id)
		{
			var result = await _testRepository.GetTestByIdAsync(id);
			return View(result);
		}

		// POST: Admin/Test/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(int id, IFormCollection collection)
		{
			await _testRepository.DeleteTestAsync(id);
			return View();
		}

		private bool TestExists(int id)
		{
			return _context.Tests.Any(e => e.Id == id);
		}
	}
}