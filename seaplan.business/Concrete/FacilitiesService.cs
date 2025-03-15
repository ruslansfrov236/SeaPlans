namespace seaplan.business.Concrete;

public class FacilitiesService : IFacilitiesService
{
    private readonly IFacilitiesReadRepository _read;
    private readonly IFacilitiesWriteRepository _write;

    public FacilitiesService(IFacilitiesReadRepository read, IFacilitiesWriteRepository write)
    {
        _read = read;
        _write = write;
    }

    public async Task<List<Facilities>> GetAll()
    {
        return await _read.GetAll().ToListAsync();
    }

    public async Task<Facilities> GetById(string id)
    {
        if (!Guid.TryParse(id, out var guid))
            throw new BadRequestException("Invalid ID format. Please provide a valid GUID.");
        var facilities = await _read.GetById(guid.ToString()) ?? throw new NotFoundException();

        return facilities;
    }

    public async Task<bool> Create(CreateFacilitiesVM model)
    {
        var facilities = new Facilities
        {
            Icon = model.Icon,
            Title = model.Title
        };
        await _write.AddAsync(facilities);
        await _write.SaveAsync();
        return true;
    }

    public async Task<bool> Update(UpdateFacilitiesVM model)
    {
        if (!Guid.TryParse(model.Id, out var guid))
            throw new BadRequestException("Invalid ID format. Please provide a valid GUID.");
        var facilities = await _read.GetById(guid.ToString()) ?? throw new NotFoundException();
        facilities.Title = model.Title;
        _write.Update(facilities);
        await _write.SaveAsync();
        return true;
    }

    public async Task<bool> Delete(string id)
    {
        if (!Guid.TryParse(id, out var guid))
            throw new BadRequestException("Invalid ID format. Please provide a valid GUID.");
        var facilities = await _read.GetById(guid.ToString()) ?? throw new NotFoundException();
        _write.Remove(facilities);
        await _write.SaveAsync();
        return true;
    }
}