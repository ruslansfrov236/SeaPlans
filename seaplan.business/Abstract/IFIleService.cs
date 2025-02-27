using Microsoft.AspNetCore.Http;

namespace seaplan.business.Abstract;

public interface IFileService
{
    Task<string> UploadAsync(IFormFile file);
    Task<ICollection<string>> UploadTotalAsync(IFormFileCollection file);

    bool IsImage(IFormFile file);
    bool CheckSize(IFormFile file, int maxSize);
    void Delete(string path);
}