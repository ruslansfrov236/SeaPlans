using System.ComponentModel.DataAnnotations;
using seaplan.entity.Entities.Common;

namespace seaplan.entity.Entities;

public class ExtraServices : BaseEntity
{
    public bool Massage { get; set; }

    [Display(Name = "Room Clean")] public bool RoomClean { get; set; }

    [Display(Name = "Wellness & Spa")] public bool WellnessSpa { get; set; }

    [Display(Name = "10$/Person")] public int Person1 { get; set; }

    [Display(Name = "15$/Person")] public int Person2 { get; set; }

    public Guid ReservationId { get; set; }
    public Reservation Reservation { get; set; }
}