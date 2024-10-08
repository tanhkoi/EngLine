﻿using CloudinaryDotNet;
using Microsoft.AspNetCore.Identity;

namespace EngLine.Models
{
	public class Teacher : ApplicationUser
	{
		public string Description { get; set; }
		public string? Photo { get; set; }

		public ICollection<TeacherCertificate> TeacherCertificates { get; set; }
		public ICollection<Course> Courses { get; set; }
		public ICollection<Test> Tests { get; set; }
	}

}
