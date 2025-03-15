namespace seaplan.business.Abstract;

public interface IProductService
{
    Task<List<Products>> GetAll();
    Task<List<Products>> GetGroupProductCategory();
    Task<Products> GetById(string id);
    Task<bool> Create(CreateProductVM model);
    Task<bool> Update(UpdateProductVM model);
    Task<bool> Delete(string id);
}