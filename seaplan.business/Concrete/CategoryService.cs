
namespace seaplan.business.Concrete;

public class CategoryService : ICategoryService
{
    private readonly ICategoryReadRepository _categoryReadRepository;
    private readonly ICategoryWriteRepository _categoryWriteRepository;

    public CategoryService(ICategoryReadRepository categoryReadRepository,
        ICategoryWriteRepository categoryWriteRepository)
    {
        _categoryReadRepository = categoryReadRepository;
        _categoryWriteRepository = categoryWriteRepository;
    }

    public async Task<List<Category>> GetAll()
    {
        var category = await _categoryReadRepository.GetAll()
            .Include(a => a.Products).Select(a => new Category
            {
                Id = a.Id,
                Name = a.Name,
                Count = a.Products.Where(p => p.CategoryId == a.Id).Count()
            }).ToListAsync();

        return category;
    }

    public async Task<Category> GetById(string id)
    {
        if (!Guid.TryParse(id, out var guid))
            throw new BadRequestException("Invalid ID format. Please provide a valid GUID.");

        var category = await _categoryReadRepository.GetById(id) ?? throw new NotFoundException();
        return category;
    }

    public async Task<bool> Create(CreateCategoryVM model)
    {
        await _categoryWriteRepository.AddAsync(new Category
        {
            Name = model.Name
        });
        await _categoryWriteRepository.SaveAsync();

        return true;
    }

    public async Task<bool> Update(UpdateCategoryVM model)
    {
        if (!Guid.TryParse(model.Id, out var guid))
            throw new BadRequestException("Invalid ID format. Please provide a valid GUID.");

        var category = await _categoryReadRepository.GetById(guid.ToString())
                       ?? throw new NotFoundException();
        category.Name = model.Name;
        _categoryWriteRepository.Update(category);
        await _categoryWriteRepository.SaveAsync();
        return true;
    }

    public async Task<bool> Delete(string id)
    {
        if (!Guid.TryParse(id, out var guid))
            throw new BadRequestException("Invalid ID format. Please provide a valid GUID.");

        var category = await _categoryReadRepository.GetById(guid.ToString())
                       ?? throw new NotFoundException();
        _categoryWriteRepository.Remove(category);
        await _categoryWriteRepository.SaveAsync();
        return true;
    }
}