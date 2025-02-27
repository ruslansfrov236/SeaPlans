namespace seaplan.business.Concrete;

public class FileService : IFileService
{
    public void Delete(string path)
    {
        if (File.Exists(path))
            File.Delete(path);
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
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ui/temp_/", filename);
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ui/image/", filename);
            var pngPath = Path.ChangeExtension(imagePath, "png");
            using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
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
        if (file == null || file.Length == 0) return false;


        if (!file.ContentType.StartsWith("image/")) return false;


        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
        var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
        if (!allowedExtensions.Contains(fileExtension)) return false;

        return true;
    }


    public async Task<string> UploadAsync(IFormFile file)
    {
        var filename = $"{Guid.NewGuid()}_{Path.GetFileNameWithoutExtension(file.FileName)}.png";
        var tempPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ui/temp_/", file.FileName);
        var pngPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ui/image", filename);


        using (var fileStream = new FileStream(tempPath, FileMode.Create, FileAccess.Write))
        {
            await file.CopyToAsync(fileStream);
        }


        using (var image = await Image.LoadAsync(tempPath))
        {
            await image.SaveAsync(pngPath, new PngEncoder());
        }


        File.Delete(tempPath);

        return filename;
    }
}