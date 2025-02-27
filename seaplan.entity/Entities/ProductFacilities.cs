using seaplan.entity.Entities.Common;

namespace seaplan.entity.Entities;

public class ProductFacilities : BaseEntity
{
    public Guid ProductId { get; set; }
    public Products Product { get; set; }

    public Guid FacilityId { get; set; }
    public Facilities Facility { get; set; }
}