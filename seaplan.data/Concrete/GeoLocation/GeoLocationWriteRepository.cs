using seaplan.data.Context;
using seaplan.entity.Entities;

namespace seaplan.data.Repository.Concrete;

public class GeoLocationWriteRepository : WriteRepository<GeoLocation>, IGeoLocationWriteRepository
{
    public GeoLocationWriteRepository(AppDbContext context) : base(context)
    {
    }
}