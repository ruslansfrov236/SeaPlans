using seaplan.entity.Entities.Common;

namespace seaplan.entity.Entities;

public class Messages : BaseEntity
{
    public string FullName { get; set; }
    public string Email { get; set; }

    public string Comment { get; set; }
}