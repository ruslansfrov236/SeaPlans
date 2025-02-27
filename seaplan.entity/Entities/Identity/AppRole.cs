using Microsoft.AspNetCore.Identity;
using seaplan.entity.Entities.Enum;

namespace seaplan.entity.Entities.Identity;

public class AppRole : IdentityRole<string>
{
    public RoleModel RoleModel { get; set; }
}