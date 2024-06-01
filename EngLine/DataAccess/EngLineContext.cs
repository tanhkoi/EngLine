using EngLine.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EngLine.ViewModels;

namespace EngLine.DataAccess
{
	public class EngLineContext : IdentityDbContext
	{
		public EngLineContext(DbContextOptions<EngLineContext> options)
			: base(options)
		{
		}
		public DbSet<ApplicationUser> ApplicationUsers { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Certificate> Certificates { get; set; }
		public DbSet<TeacherCertificate> TeacherCertificates { get; set; }
		public DbSet<TutorLesson> TutorLessons { get; set; }
		public DbSet<TimeSlot> TimeSlots { get; set; }
		public DbSet<Booking> Bookings { get; set; }
		public DbSet<PaymentMethod> PaymentMethods { get; set; }
		public DbSet<OrderPayment> OrderPayments { get; set; }
		public DbSet<BookingPayment> BookingPayments { get; set; }
		public DbSet<Test> Tests { get; set; }
		public DbSet<Question> Questions { get; set; }
		public DbSet<AnswerOption> AnswerOptions { get; set; }
		public DbSet<Answer> Answers { get; set; }
		public DbSet<StudentResponse> StudentResponses { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Lesson> Lessons { get; set; }
		public DbSet<Order> Orders { get; set; }
	}
}