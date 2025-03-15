using seaplan.business.ViewsModels.Slider;
using seaplan.entity;
using task.Webui.ViewsModels.Slider;

namespace seaplan.business.Concrete;

public class SliderService : ISliderService
{
    private readonly IFileService _fileService;
    private readonly ISliderReadRepository _read;
    private readonly ISliderWriteRepository _write;

    public SliderService(ISliderReadRepository read, ISliderWriteRepository write, IFileService fileService)
    {
        _read = read;
        _write = write;
        _fileService = fileService;
    }

    public async Task<List<Slider>> GetAll()
    {
        return await _read.GetAll().ToListAsync();
    }

    public async Task<Slider> GetById(string id)
    {
        if (!Guid.TryParse(id, out var guid))
            throw new BadRequestException("Invalid ID format. Please provide a valid GUID.");

        var slider = await _read.GetById(guid.ToString()) ?? throw new NotFoundException();

        return slider;
    }

    public async Task<bool> Create(CreateSliderVM model)
    {
        var newImage = await _fileService.UploadAsync(model.FormFile);
        var slider = new Slider
        {
            Title = model.Title,
            Description = model.Description,
            Photo = newImage
        };
        await _write.AddAsync(slider);
        await _write.SaveAsync();
        return true;
    }

    public async Task<bool> Update(UpdateSliderVM model)
    {
        if (!Guid.TryParse(model.Id, out var guid))
            throw new BadRequestException("Invalid ID format. Please provide a valid GUID.");

        var slider = await _read.GetById(guid.ToString()) ?? throw new NotFoundException();

        if (model.FormFile != null)
        {
            _fileService.Delete(slider.Photo);
            var newImage = await _fileService.UploadAsync(model.FormFile);

            slider.Photo = newImage;
        }

        slider.Title = model.Title;
        slider.Description = model.Descriptions;
        _write.Update(slider);
        await _write.SaveAsync();

        return true;
    }

    public async Task<bool> Delete(string id)
    {
        if (!Guid.TryParse(id, out var guid))
            throw new BadRequestException("Invalid ID format. Please provide a valid GUID.");

        var slider = await _read.GetById(guid.ToString()) ?? throw new NotFoundException();
        _fileService.Delete(slider.Photo);
        _write.Remove(slider);
        await _write.SaveAsync();
        return true;
    }
}