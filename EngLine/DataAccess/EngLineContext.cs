using EngLine.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EngLine.DataAccess
{
	public class EngLineContext : IdentityDbContext<Account>
	{
		public EngLineContext(DbContextOptions<EngLineContext> options) : base(options) { }
		public DbSet<Account> Accounts { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Class> Classes { get; set; }
		public DbSet<ClassStudent> ClassStudents { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Level> Levels { get; set; }
		public DbSet<Payment> Payments { get; set; }
		public DbSet<PaymentMethod> PaymentMethods { get; set; }
		public DbSet<StaffAccount> StaffAccounts { get; set; }
		public DbSet<StudentAccount> StudentAccounts { get; set; }
		public DbSet<TeacherAccount> TeacherAccounts { get; set; }
	}
}
