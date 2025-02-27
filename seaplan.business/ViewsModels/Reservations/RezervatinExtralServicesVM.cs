using seaplan.entity.Entities;

namespace seaplan.business.ViewsModels;

public class RezervatinExtralServicesVM
{
    public Reservation Reservations { get; set; }

    public ICollection<entity.Entities.ExtraServices> ExtraServices { get; set; }
}