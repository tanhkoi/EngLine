using EngLine.DataAccess;
using EngLine.Models;
using EngLine.Repositories;
using EngLine.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EngLine.Controllers
{
	public class TestController : Controller
	{
		private readonly EngLineContext _context;
		private readonly IStudentRepository _studentRepository;

		public TestController(EngLineContext context, IStudentRepository studentRepository)
		{
			_context = context;
			_studentRepository = studentRepository;
		}

		public IActionResult TakeTest(int testId = 1)
		{
			var test = _context.Tests
				.Include(t => t.Questions)
				.ThenInclude(q => q.AnswerOptions)
				.FirstOrDefault(t => t.Id == testId);

			if (test == null)
			{
				return NotFound();
			}

			var viewModel = new TestViewModel
			{
				Test = test,
				Questions = test.Questions.ToList()
			};

			return View(viewModel);
		}

		[HttpPost]
		public IActionResult SubmitTest(IFormCollection form)
		{
			var studentId = "1";
			//var testId = int.Parse(form["TestId"]);
			var testId = 1;
			var response = new StudentResponse
			{
				StudentId = studentId,
				TestId = testId,
				Score = 0 // Calculate the score based on answers
			};

			_context.StudentResponses.Add(response);
			_context.SaveChanges();

			foreach (var key in form.Keys)
			{
				if (key.StartsWith("question_"))
				{
					var questionId = int.Parse(key.Split('_')[1]);
					var selectedAnswerId = int.Parse(form[key]);

					var answer = new Answer
					{
						QuestionId = questionId,
						Content = "Content",
						SelectedAnswerId = selectedAnswerId,
						StudentResponseId = response.Id
					};

					_context.Answers.Add(answer);
				}
			}

			_context.SaveChanges();

			// Redirect to a result page or confirmation page
			return RedirectToAction("Result", new { id = response.Id });
		}

		public IActionResult Result(int id)
		{
			var response = _context.StudentResponses
				.Include(r => r.Answers)
				.FirstOrDefault(r => r.Id == id);

			if (response == null)
			{
				return NotFound();
			}

			return View(response);
		}

	}
}
