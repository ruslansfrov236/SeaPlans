using seaplan.entity.Entities.Enum;
using seaplan.entity.Entities.Identity;

namespace seaplan.business.ViewsModels.Reservations;

public class UpdateReservationVM
{
    public string Id { get; set; }

    public string UserId { get; set; }
    public Status Status { get; set; }
    public AppUser User { get; set; }
    public ICollection<entity.Entities.Order> Order { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public long Rooms { get; set; }
    public long Adults { get; set; }
    public long Children { get; set; }

    public entity.Entities.Products Products { get; set; }
    public entity.Entities.ExtraServices ExtraServices { get; set; }
}