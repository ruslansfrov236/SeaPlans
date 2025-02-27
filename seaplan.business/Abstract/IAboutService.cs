using seaplan.business.ViewsModels.About;

namespace seaplan.business.Abstract;

public interface IAboutService
{
    Task<List<About>> GetAll();
    Task<About> GetById(string id);
    Task<bool> Create(CreateAboutVM model);
    Task<bool> Update(UpdateAboutVM model);
    Task<bool> Delete(string id);
}