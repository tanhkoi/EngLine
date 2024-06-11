using EngLine.Models;

namespace EngLine.Utilitys
{
	public static class TeacherExtensions
	{
		public static TeacherViewModel ToViewModel(this Teacher teacher)
		{
			return new TeacherViewModel
			{
				Id = teacher.Id,
				Username = teacher.UserName,
				Email = teacher.Email,
				FirstName = teacher.FirstName,
				LastName = teacher.LastName,
				PhoneNumber = teacher.PhoneNumber,
				Description = teacher.Description,
				Photo = teacher.Photo,
				IsActive = teacher.IsActive
			};
		}

		public static Teacher ToEntity(this TeacherViewModel viewModel)
		{
			return new Teacher
			{
				Id = viewModel.Id,
				UserName = viewModel.Username,
				Email = viewModel.Email,
				FirstName = viewModel.FirstName,
				LastName = viewModel.LastName,
				PhoneNumber = viewModel.PhoneNumber,
				Description = viewModel.Description,
				Photo = viewModel.Photo,
				IsActive = viewModel.IsActive
			};
		}
	}

}
