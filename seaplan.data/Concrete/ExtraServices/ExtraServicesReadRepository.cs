using seaplan.data.Context;
using seaplan.entity.Entities;

namespace seaplan.data.Repository.Concrete;

public class ExtraServicesReadRepository : ReadRepository<ExtraServices>, IExtraServiceReadRepository
{
    public ExtraServicesReadRepository(AppDbContext context) : base(context)
    {
    }
}