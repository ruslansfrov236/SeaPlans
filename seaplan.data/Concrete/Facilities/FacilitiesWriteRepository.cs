using seaplan.data.Context;
using seaplan.entity.Entities;

namespace seaplan.data.Repository.Concrete;

public class FacilitiesWriteRepository : WriteRepository<Facilities>, IFacilitiesWriteRepository
{
    public FacilitiesWriteRepository(AppDbContext context) : base(context)
    {
    }
}