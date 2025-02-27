using seaplan.data.Context;
using seaplan.entity.Entities;

namespace seaplan.data.Repository.Concrete;

public class HeaderWriteRepository : WriteRepository<Header>, IHeaderWriteRepository
{
    public HeaderWriteRepository(AppDbContext context) : base(context)
    {
    }
}