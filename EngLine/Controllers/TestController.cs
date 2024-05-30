using System.Security.Claims;
using EngLine.DataAccess;
using EngLine.Models;
using EngLine.Repositories;
using EngLine.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EngLine.Controllers
{
	[Authorize]
	public class TestController : Controller
	{
		private readonly IStudentRepository _studentRepository;
		private readonly ITestRepository _testRepository;
		private readonly IStudentResponseRepository _studentResponseRepository;
		private readonly IAnswerRepository _answerRepository;

		public TestController(
		IStudentRepository studentRepository,
		ITestRepository testRepository,
		IStudentResponseRepository studentResponseRepository,
		IAnswerRepository answerRepository
		)
		{
			_studentRepository = studentRepository;
			_testRepository = testRepository;
			_studentResponseRepository = studentResponseRepository;
			_answerRepository = answerRepository;
		}

		public async Task<IActionResult> TakeTest(int testId = 1)
		{
			var test = await _testRepository.GetTestByIdAsync(testId);

			var viewModel = new TestViewModel
			{
				Test = test,
				Questions = test.Questions.ToList()
			};
			return View(viewModel);
		}

		[HttpPost]
		public async Task<IActionResult> SubmitTest(IFormCollection form, int testId)
		{
			var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			var response = new StudentResponse()
			{
				StudentId = studentId,
				TestId = testId,
				Score = 0
			};

			await _studentResponseRepository.AddStudentResponseAsync(response);

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
					await _answerRepository.AddAnswerAsync(answer);
				}
			}

			response.Score = await _studentResponseRepository.CalculateScore(studentId, testId, response.Id);
			await _studentResponseRepository.UpdateStudentResponseAsync(response);

			// Redirect to a result page or confirmation page
			return RedirectToAction("Result", new { id = response.Id });
		}

		public async Task<IActionResult> Result(int id)
		{
			var response = await _studentResponseRepository.GetStudentResponseByIdAsync(id);
			return View(response);
		}

	}
}
