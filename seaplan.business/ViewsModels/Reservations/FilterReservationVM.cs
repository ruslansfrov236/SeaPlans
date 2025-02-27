using seaplan.entity.Entities;

namespace seaplan.business.ViewsModels.Reservations;

public class FilterReservationVM
{
    
    public ICollection<Reservation> Reservations { get; set; }
    public DateTime? CheckIn { get; set; }
    public DateTime? CheckOut { get; set; }
    public long? Rooms { get; set; }
    public long? Adults { get; set; }
    public long? Children { get; set; }
}