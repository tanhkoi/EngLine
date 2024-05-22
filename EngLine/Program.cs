using EngLine.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using EngLine.Models;
using EngLine.Utilitys;
using Microsoft.AspNetCore.Identity.UI.Services;
using EngLine.Repositories;
using EngLine.Repositories.EF;
//using CloudinaryDotNet;
//using CloudinaryDotNet.Actions;
//using EngLine.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Database access
builder.Services.AddDbContext<EngLineContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services: Repositories
//builder.Services.AddScoped<IPaymentRepository, EFPaymentRepository>();
//builder.Services.AddScoped<ICourseRepository, EFCourseRepository>();
//builder.Services.AddScoped<IClassRepository, EFClassRepository>();
//builder.Services.AddScoped<IUserRepository, EFUserRepository>();
builder.Services.AddScoped<ITestRepository, EFTestRepository>();
builder.Services.AddScoped<IQuestionRepository, EFQuestionRepository>();
builder.Services.AddScoped<IEmailSender, EmailSender>();

// Add services: User Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
	.AddDefaultTokenProviders()
	.AddDefaultUI()
	.AddEntityFrameworkStores<EngLineContext>();
builder.Services.AddRazorPages();

// Add services: Cloudinary.
builder.Services.Configure<CloudinarySettings>(builder.Configuration.GetSection("CloudinarySettings"));
builder.Services.AddSingleton<CloudinaryService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}

//Cloudinary
//Account account = new Account(
//  "dcrftc3n9",
//  "744696573532998",
//  "oOULAD1ok4pjf4K-Cv0ITpIttMw");
//Account account = new Account(
//  "dqnmqwbqy",
//  "666116648429635",
//  "QiQfDk4B1BXc9ECnnr6LARhmwTU");

//Cloudinary cloudinary = new Cloudinary(account);

//cloudinary.Api.Secure = true;

app.UseHttpsRedirection();

app.UseStaticFiles();

app.MapRazorPages();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "Teacher",
	pattern: "{area:exists}/{controller=Teacher}/{action=Index}/{id?}"
);

app.MapControllerRoute(
	name: "Admin",
	pattern: "{area:exists}/{controller=Manage}/{action=Index}/{id?}"
);

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();