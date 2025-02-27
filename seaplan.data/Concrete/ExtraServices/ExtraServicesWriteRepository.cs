using seaplan.data.Context;
using seaplan.entity.Entities;

namespace seaplan.data.Repository.Concrete;

public class ExtraServicesWriteRepository : WriteRepository<ExtraServices>, IExtraServiceWriteRepository
{
    public ExtraServicesWriteRepository(AppDbContext context) : base(context)
    {
    }
}