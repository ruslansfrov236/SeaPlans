using seaplan.data.Context;
using seaplan.entity.Entities;

namespace seaplan.data.Repository.Concrete;

public class GeoLocationReadRepository : ReadRepository<GeoLocation>, IGeoLocationReadRepository
{
    public GeoLocationReadRepository(AppDbContext context) : base(context)
    {
    }
}