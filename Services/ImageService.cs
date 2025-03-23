using projects.Interfaces;

namespace projects.Services;
public class ImageService(IWebHostEnvironment webHostEnvironment) : IImageService
{
    private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

    public async Task<string> UploadImageAsync(IFormFile imageFile)
    {
        if (imageFile == null || imageFile.Length == 0)
        {
            throw new ArgumentException("Invalid image file.");
        }

        var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(imageFile.FileName)}";

        // Ensure the correct folder name is "uploads"
        var uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
        Directory.CreateDirectory(uploadFolder); // Ensure the directory exists

        var uploadPath = Path.Combine(uploadFolder, fileName);

        using (var stream = new FileStream(uploadPath, FileMode.Create))
        {
            await imageFile.CopyToAsync(stream);
        }

        return $"/uploads/{fileName}"; // Ensure it matches the static files serving path
    }
}
