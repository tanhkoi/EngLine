using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using EngLine.Utilitys;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

public class CloudinaryService
{
	private readonly Cloudinary _cloudinary;

	public CloudinaryService(IOptions<CloudinarySettings> cloudinaryConfig)
	{
		var config = cloudinaryConfig.Value;
		_cloudinary = new Cloudinary(new Account(
			config.CloudName,
			config.ApiKey,
			config.ApiSecret));
	}

	public async Task<ImageUploadResult> UploadImageAsync(IFormFile file)
	{
		var uploadResult = new ImageUploadResult();

		if (file.Length > 0)
		{
			using (var stream = file.OpenReadStream())
			{
				var uploadParams = new ImageUploadParams()
				{
					File = new FileDescription(file.FileName, stream)
				};
				uploadResult = await _cloudinary.UploadAsync(uploadParams);
			}
		}

		return uploadResult;
	}

	public async Task<RawUploadResult> UploadAudioAsync(IFormFile file)
	{
		var uploadResult = new RawUploadResult();

		if (file.Length > 0)
		{
			using (var stream = file.OpenReadStream())
			{
				var uploadParams = new RawUploadParams()
				{
					File = new FileDescription(file.FileName, stream)
				};
				uploadResult = await _cloudinary.UploadAsync(uploadParams);
			}
		}

		return uploadResult;
	}

}
