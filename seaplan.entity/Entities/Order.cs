using seaplan.entity.Entities.Common;

namespace seaplan.entity.Entities;

public class Order : BaseEntity
{
    public string? FullName { get; set; }
    public string? LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string? Description { get; set; }
    public string? Address { get; set; }
    public string? OrderCode { get; set; }
    public Guid ReservationId { get; set; }
    public ICollection<Reservation> Reservation { get; set; }

    public OrderItem OrderItem { get; set; }
}