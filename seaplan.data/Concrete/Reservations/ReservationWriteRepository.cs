using seaplan.data.Context;
using seaplan.entity.Entities;

namespace seaplan.data.Repository.Concrete;

public class ReservationWriteRepository : WriteRepository<Reservation>, IReservationWriteRepository
{
    public ReservationWriteRepository(AppDbContext context) : base(context)
    {
    }
}