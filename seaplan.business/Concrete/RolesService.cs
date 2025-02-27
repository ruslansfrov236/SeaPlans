using Microsoft.AspNetCore.Identity;
using seaplan.business.ViewsModels.Auth;
using seaplan.entity.Entities.Identity;
using task.Webui.ViewsModels.Auth;

namespace seaplan.business.Concrete;

public class RolesService:IRolesService
{
    readonly private RoleManager<AppRole> _roleManager;

    public RolesService(RoleManager<AppRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<List<AppRole>> GetAll()
        => await _roleManager.Roles.ToListAsync();

    public async Task<AppRole> GetById(string id)
    {
        if (!Guid.TryParse(id, out var guid))
            throw new BadRequestException("Invalid ID format. Please provide a valid GUID.");
        var roles = await _roleManager.FindByIdAsync(guid.ToString())?? throw new NotFoundException();
        return roles;
    }

    public async Task<bool> Create(CreateRolesVM model)
    {
        AppRole role = new AppRole()
        {
            Name = model.Name,
            ConcurrencyStamp = model.Name.ToLower(),
            RoleModel = model.RoleModel
        };
        await _roleManager.CreateAsync(role);
        return true;
    }

    public async Task<bool> Update(UpdateRolesVM model)
    {
        if (!Guid.TryParse(model.Id, out var guid))
            throw new BadRequestException("Invalid ID format. Please provide a valid GUID.");
        var roles = await _roleManager.FindByIdAsync(guid.ToString())?? throw new NotFoundException();

        roles.RoleModel = model.RoleModel;
        roles.Name = model.Name;
        roles.ConcurrencyStamp = model.Name.ToLower();
        
        await _roleManager.UpdateAsync(roles);

        return true;
    }

    public async Task<bool> Delete(string id)
    {
        if (!Guid.TryParse(id, out var guid))
            throw new BadRequestException("Invalid ID format. Please provide a valid GUID.");
        var roles = await _roleManager.FindByIdAsync(guid.ToString())?? throw new NotFoundException();
        await _roleManager.DeleteAsync(roles);

        return true;
    }
}