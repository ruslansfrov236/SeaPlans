using seaplan.business.ViewsModels.Header;

namespace seaplan.business.Abstract;

public interface IHeaderService
{
    Task<List<Header>> GetAll();
    Task<Header> GetById(string id);
    Task<bool> Create(CreateHeaderVM model);
    Task<bool> Update(UpdateHeaderVM model);
    Task<bool> Delete(string id);
}