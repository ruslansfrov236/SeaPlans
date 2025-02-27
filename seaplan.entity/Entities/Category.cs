using seaplan.entity.Entities.Common;

namespace seaplan.entity.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }

    public long Count { get; set; }

    public ICollection<Products> Products { get; set; }
}