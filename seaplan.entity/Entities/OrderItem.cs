using seaplan.entity.Entities.Common;
using seaplan.entity.Entities.Identity;

namespace seaplan.entity.Entities;

public class OrderItem : BaseEntity
{
    public decimal TotalPrice { get; set; }

    public decimal Tax { get; set; }

    public string UserId { get; set; }

    public AppUser User { get; set; }
    public Guid OrderId { get; set; }

    public Order Order { get; set; }
}