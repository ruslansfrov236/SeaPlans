namespace seaplan.business.Concrete;

public class FileService : IFileService
{
    private readonly IWebHostEnvironment _env;

    public FileService(IWebHostEnvironment env)
    {
        _env = env;
    }

    public void Delete(string path)
    {
        var fullpath = Path.Combine(_env.WebRootPath, "assets/image", path);

        if (File.Exists(fullpath))
            File.Delete(fullpath);
    }

    public bool CheckSize(IFormFile file, int maxSize)
    {
        if (file.Length / 1024 < maxSize) return false;
        return true;
    }


    public async Task<ICollection<string>> UploadTotalAsync(IFormFileCollection files)
    {
        var uploadFiles = new List<string>();
        foreach (var file in files)
        {
            var filename = $"{Guid.NewGuid()}_{file.FileName}";
            var tempPath = Path.Combine(_env.WebRootPath, "assets/temp" + file.FileName);
            var imagePath = Path.Combine(_env.WebRootPath, "assets/image", filename);
            var pngPath = Path.ChangeExtension(imagePath, "png");
            using (var fileStream = new FileStream(tempPath, FileMode.Create, FileAccess.ReadWrite))
            {
                await file.CopyToAsync(fileStream);
            }

            using (var image = await Image.LoadAsync(pngPath))
            {
                await image.SaveAsync(pngPath, new PngEncoder());
            }

            File.Delete(imagePath);

            uploadFiles.Add(pngPath);
        }


        return uploadFiles;
    }

    public bool IsImage(IFormFile file)
    {
        if (file.Length == 0) return false;


        if (!file.ContentType.StartsWith("image/")) return false;


        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
        var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
        if (!allowedExtensions.Contains(fileExtension)) return false;

        return true;
    }


    public async Task<string> UploadAsync(IFormFile file)
    {
        var filename = $"{Guid.NewGuid()}_{Path.GetFileNameWithoutExtension(file.FileName)}.png";
        var tempPath = Path.Combine(_env.WebRootPath, "assets/temp" + file.FileName);
        var imagePath = Path.Combine(_env.WebRootPath, "assets/image", filename);


        using (var fileStream = new FileStream(tempPath, FileMode.Create, FileAccess.Write))
        {
            await file.CopyToAsync(fileStream);
        }


        using (var image = await Image.LoadAsync(tempPath))
        {
            await image.SaveAsync(imagePath, new PngEncoder());
        }


        File.Delete(tempPath);

        return filename;
    }
}