using seaplan.entity.Entities.Common;

namespace seaplan.entity.Entities;

public class Facilities : BaseEntity
{
    public ICollection<ProductFacilities> ProductFacilities { get; set; }
    public string Title { get; set; }
    public string Icon { get; set; }
}