using System.Security.Claims;
using EngLine.Models;
using EngLine.Models.Services;
using EngLine.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EngLine.Controllers
{
	[Authorize]
	public class ShoppingCartController : Controller
	{
		private readonly IStudentRepository _studentRepository;
		private readonly ICourseRepository _courseRepository;
		private readonly IPaymentMethodRepository _paymentMethodRepository;
		private readonly IVnPayService _vnPayService;
		private readonly IOrderRepository _orderRepository;

		public ShoppingCartController(
			IStudentRepository studentRepository,
			ICourseRepository courseRepository,
			IPaymentMethodRepository paymentMethodRepository,
			IVnPayService vnPayService,
			IOrderRepository orderRepository
		)
		{
			_studentRepository = studentRepository;
			_courseRepository = courseRepository;
			_paymentMethodRepository = paymentMethodRepository;
			_vnPayService = vnPayService;
			_orderRepository = orderRepository;
		}

		public async Task<IActionResult> Checkout(int courseid)
		{
			var student = await _studentRepository.GetStudentByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier));
			if (student == null)
			{
				return NotFound();
			}

			ViewBag.paymentMethod = await _paymentMethodRepository.GetAllPaymentMethodAsync();

			var course = await _courseRepository.GetCourseByIdAsync(courseid);
			return View(course);
		}

		[HttpPost]
		public async Task<IActionResult> Checkout(Order order, int paymentMethodId, double amount, int courseId)
		{
			order.CourseId = courseId;
			order.Status = "Pendding";
			order.StudentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			order.OrderTime = DateTime.Now;
			order.Amount = amount;
			await _orderRepository.AddOrderAsync(order);

			// id = 2: VnPay
			if (paymentMethodId == 2)
			{
				var vnPayModel = new VnPayRequestModel
				{
					Amount = order.Amount,
					CreatedDate = order.OrderTime,
					Description = "Thanh toán đơn hàng",
					OrderId = order.Id
				};
				return Redirect(_vnPayService.CreatePaymentUrl(HttpContext, vnPayModel));
			}
			return View("OrderCompleted", paymentMethodId);
		}

		public IActionResult PaymentCallBack()
		{
			var response = _vnPayService.PaymentExcute(Request.Query);
			if (response == null || response.VnPayResponseCode != "00")
			{

				TempData["Message"] = $"Lỗi thanh toán VN Pay: {response.VnPayResponseCode}";
				return RedirectToAction("PaymentFail");
			}

			TempData["Message"] = "Thanh toán Vnpay thành công";
			return RedirectToAction("PaymentSuccess", new { orderId = response.OrderId });
		}

		public async Task<IActionResult> PaymentSuccess(int orderId)
		{
			var order = await _orderRepository.GetOrderByIdAsync(orderId);
			order.Status = "Success";
			await _orderRepository.UpdateOrderAsync(order);

			TempData["OrderSuccessMessage"] = "Thanh toán thành công!";

			return RedirectToAction("CourseDetails", "Home", new { id = order.CourseId });
		}

		public IActionResult PaymentFail()
		{
			return View();
		}
	}
}
