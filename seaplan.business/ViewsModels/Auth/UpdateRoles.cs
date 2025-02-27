using seaplan.entity.Entities.Enum;

namespace task.Webui.ViewsModels.Auth;

public class UpdateRoles
{
    public string Id { get; set; }
    public string Name { get; set; }
    public RoleModel RoleModel { get; set; }
}