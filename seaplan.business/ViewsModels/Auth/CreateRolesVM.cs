using seaplan.entity.Entities.Enum;

namespace seaplan.business.ViewsModels.Auth;

public class CreateRolesVM
{
    public string Name { get; set; }
    public RoleModel RoleModel { get; set; }
}