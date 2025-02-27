using seaplan.business.ViewsModels.About;

namespace seaplan.business.Concrete;

public class AboutService : IAboutService
{
    private readonly IFileService _fileService;
    private readonly IAboutReadRepository _read;
    private readonly IAboutWriteRepository _write;

    public AboutService(IAboutReadRepository read, IAboutWriteRepository write, IFileService fileService)
    {
        _read = read;
        _write = write;
        _fileService = fileService;
    }

    public async Task<List<About>> GetAll()
    {
        return await _read.GetAll().ToListAsync();
    }


    public async Task<About> GetById(string id)
    {
        if (!Guid.TryParse(id, out var guid))
            throw new BadRequestException("Invalid ID format. Please provide a valid GUID.");

        var about = await _read.GetById(guid.ToString()) ?? throw new NotFoundException();
        return about;
    }

    public async Task<bool> Create(CreateAboutVM model)
    {
        var newFile = await _fileService.UploadAsync(model.FormFile);

        var about = new About
        {
            Title = model.Title,
            Descripition = model.Descripition,
            BgImage = newFile
        };
        await _write.AddAsync(about);
        await _write.SaveAsync();

        return true;
    }

    public async Task<bool> Update(UpdateAboutVM model)
    {
        if (!Guid.TryParse(model.id, out var guid))
            throw new BadRequestException("Invalid ID format. Please provide a valid GUID.");

        var about = await _read.GetById(guid.ToString()) ?? throw new NotFoundException();

        if (model.FormFile != null)
        {
            _fileService.Delete(model.BgImage);
            var newFile = await _fileService.UploadAsync(model.FormFile);
            about.BgImage = newFile;
        }

        about.Title = model.Title;
        about.Descripition = model.Descripition;

        _write.Update(about);
        await _write.SaveAsync();
        return true;
    }

    public async Task<bool> Delete(string id)
    {
        if (!Guid.TryParse(id, out var guid))
            throw new BadRequestException("Invalid ID format. Please provide a valid GUID.");

        var about = await _read.GetById(guid.ToString()) ?? throw new NotFoundException();
        _fileService.Delete(about.BgImage);
        _write.Remove(about);
        await _write.SaveAsync();
        return true;
    }
}