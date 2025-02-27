using seaplan.business.ViewsModels.Header;


namespace seaplan.business.Concrete;

public class HeaderService:IHeaderService
{
    readonly private IHeaderReadRepository _read;
    readonly private IHeaderWriteRepository _write;
    readonly private IFileService _fileService;

    public HeaderService(IHeaderReadRepository read, IHeaderWriteRepository write, IFileService fileService)
    {
        _read = read;
        _write = write;
        _fileService = fileService;
    }

    public async Task<List<Header>> GetAll()
        => await _read.GetAll().ToListAsync();

    public async Task<Header> GetById(string id)
    {
        if (!Guid.TryParse(id, out var guid))
            throw new BadRequestException("Invalid ID format. Please provide a valid GUID.");

        var header = await _read.GetById(guid.ToString()) ?? throw new NotFoundException();
        return header;
    }

    public async Task<bool> Create(CreateHeaderVM model)
    {

        var newImage = await _fileService.UploadAsync(model.FileCollection);

        Header header = new Header()
        {
            Title = model.Title,
            Description = model.Description,
            Photo = newImage
        };

        await _write.AddAsync(header);
        await _write.SaveAsync();
        return true;

    }

    public async Task<bool> Update(UpdateHeaderVM model)
    {
        if (!Guid.TryParse(model.Id, out var guid))
            throw new BadRequestException("Invalid ID format. Please provide a valid GUID.");

        var header = await _read.GetById(guid.ToString()) ??throw new NotFoundException();
        
        if (model.FileCollection != null)
        {
            var newImage = await _fileService.UploadAsync(model.FileCollection);
            _fileService.Delete(model.Photo);
            header.Photo = newImage;
        }

        header.Title = model.Title;
        header.Description = model.Description;
         _write.Update(header);
        await _write.SaveAsync();
        return true;
    }

    public async Task<bool> Delete(string id)
    {
        if (!Guid.TryParse(id, out var guid))
            throw new BadRequestException("Invalid ID format. Please provide a valid GUID.");

        var header = await _read.GetById(guid.ToString()) ??throw new NotFoundException();
        _fileService.Delete(header.Photo);
        _write.Remove(header);
        await _write.SaveAsync();
        return true;
    }
}