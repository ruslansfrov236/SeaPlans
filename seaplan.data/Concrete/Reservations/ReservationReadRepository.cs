using seaplan.data.Context;
using seaplan.entity.Entities;

namespace seaplan.data.Repository.Concrete;

public class ReservationReadRepository : ReadRepository<Reservation>, IReservationReadRepository
{
    public ReservationReadRepository(AppDbContext context) : base(context)
    {
    }
}