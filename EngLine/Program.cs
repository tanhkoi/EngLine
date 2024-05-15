using EngLine.DataAccess;
using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using EngLine.Models;
using EngLine.Repositories;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Database access
builder.Services.AddDbContext<EngLineContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// sign repositories
builder.Services.AddScoped<IPaymentRepository, EFPaymentRepository>();
builder.Services.AddScoped<ICourseRepository, EFCourseRepository>();
builder.Services.AddScoped<IClassRepository, EFClassRepository>();
builder.Services.AddScoped<IUserRepository, EFUserRepository>();

// user identity
builder.Services.AddIdentity<User, IdentityRole>()
    .AddDefaultTokenProviders()
    .AddDefaultUI()
    .AddEntityFrameworkStores<EngLineContext>();
builder.Services.AddRazorPages();

// email sender
builder.Services.AddScoped<IEmailSender, EmailSender>();

//
builder.Services.ConfigureApplicationCookie(options => {
	options.LoginPath = $"/Identity/Account/Login";
	options.LogoutPath = $"/Identity/Account/Logout";
	options.LogoutPath = $"/Identity/Account/AccessDenied";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

//Cloudinary
Account account = new Account(
  "dcrftc3n9",
  "744696573532998",
  "oOULAD1ok4pjf4K-Cv0ITpIttMw");

Cloudinary cloudinary = new Cloudinary(account);
cloudinary.Api.Secure = true;

app.UseHttpsRedirection();

app.UseStaticFiles();

app.MapRazorPages();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints.MapControllerRoute(
	  name: "areas",
	  pattern: "{area:exists}/{controller=Manage}/{action=Index}/{id?}"
	);
});

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
