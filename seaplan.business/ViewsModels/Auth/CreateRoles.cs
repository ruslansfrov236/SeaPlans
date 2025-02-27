using seaplan.entity.Entities.Enum;

namespace seaplan.business.ViewsModels.Auth;

public class CreateRoles
{
    public string Name { get; set; }
    public RoleModel RoleModel { get; set; }
}