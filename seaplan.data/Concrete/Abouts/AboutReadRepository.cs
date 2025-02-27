using seaplan.data.Context;
using seaplan.entity.Entities;

namespace seaplan.data.Repository.Concrete;

public class AboutReadRepository : ReadRepository<About>, IAboutReadRepository
{
    public AboutReadRepository(AppDbContext context) : base(context)
    {
    }
}