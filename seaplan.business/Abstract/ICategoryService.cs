namespace seaplan.business.Abstract;

public interface ICategoryService
{
    Task<List<Category>> GetAll();
    Task<Category> GetById(string id);
    Task<bool> Create(CreateCategoryVM model);
    Task<bool> Update(UpdateCategoryVM model);
    Task<bool> Delete(string id);
}