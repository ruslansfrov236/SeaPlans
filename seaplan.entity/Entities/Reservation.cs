using seaplan.entity.Entities.Common;
using seaplan.entity.Entities.Enum;
using seaplan.entity.Entities.Identity;

namespace seaplan.entity.Entities;

public class Reservation : BaseEntity
{
    public AppUser User { get; set; }
    public string UserId { get; set; }

    public string RezervationCode { get; set; }
    public Status Status { get; set; } = Status.Pending;
    public ICollection<Order> Order { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public long Rooms { get; set; }
    public long Adults { get; set; }
    public long Children { get; set; }


    public Guid ProductId { get; set; }
    public Products Product { get; set; }
    public ExtraServices ExtraServices { get; set; }
}