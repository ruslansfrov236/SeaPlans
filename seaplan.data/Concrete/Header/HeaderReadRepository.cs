using seaplan.data.Context;
using seaplan.entity.Entities;

namespace seaplan.data.Repository.Concrete;

public class HeaderReadRepository : ReadRepository<Header>, IHeaderReadRepository
{
    public HeaderReadRepository(AppDbContext context) : base(context)
    {
    }
}