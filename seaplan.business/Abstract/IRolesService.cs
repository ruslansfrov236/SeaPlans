using seaplan.business.ViewsModels.Auth;
using seaplan.entity.Entities.Identity;
using task.Webui.ViewsModels.Auth;

namespace seaplan.business.Abstract;

public interface IRolesService
{
    Task<List<AppRole>> GetAll();
    Task<AppRole> GetById(string id);
    Task<bool> Create(CreateRolesVM model);
    Task<bool> Update(UpdateRolesVM model);
    Task<bool> Delete(string id);
}