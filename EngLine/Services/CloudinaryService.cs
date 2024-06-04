using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Configuration;

public class CloudinaryService
{
	private readonly Cloudinary _cloudinary;

	public CloudinaryService(IConfiguration configuration)
	{
		var cloudName = configuration["Cloudinary:CloudName"];
		var apiKey = configuration["Cloudinary:ApiKey"];
		var apiSecret = configuration["Cloudinary:ApiSecret"];

		var account = new Account(cloudName, apiKey, apiSecret);
		_cloudinary = new Cloudinary(account);
	}

	public String UploadImageAsync(IFormFile file)
	{
		try
		{
			var uploadParams = new ImageUploadParams()
			{
				File = new FileDescription(file.FileName, file.OpenReadStream())
			};
			var uploadResult = _cloudinary.Upload(uploadParams);
			return uploadResult.Uri.ToString();
		}
		catch (Exception ex)
		{
			throw new Exception("Image upload failed", ex);
		}
	}

	public String UploadVideoAsync(IFormFile file)
	{
		try
		{
			var uploadParams = new VideoUploadParams()
			{
				File = new FileDescription(file.FileName, file.OpenReadStream())
			};
			var uploadResult = _cloudinary.Upload(uploadParams);
			return uploadResult.Uri.ToString();
		}
		catch (Exception ex)
		{
			throw new Exception("Video upload failed", ex);
		}
	}
}
