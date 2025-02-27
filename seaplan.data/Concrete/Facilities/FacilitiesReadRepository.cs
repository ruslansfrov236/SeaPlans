using seaplan.data.Context;
using seaplan.entity.Entities;

namespace seaplan.data.Repository.Concrete;

public class FacilitiesReadRepository : ReadRepository<Facilities>, IFacilitiesReadRepository
{
    public FacilitiesReadRepository(AppDbContext context) : base(context)
    {
    }
}