using seaplan.entity.Entities.Common;

namespace seaplan.entity.Entities;

public class AboutHeader : BaseEntity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ButtonValues { get; set; }
}