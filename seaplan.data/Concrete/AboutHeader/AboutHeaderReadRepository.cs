using seaplan.data.Context;
using seaplan.entity.Entities;

namespace seaplan.data.Repository.Concrete;

public class AboutHeaderReadRepository : ReadRepository<AboutHeader>, IAboutHeaderReadRepository
{
    public AboutHeaderReadRepository(AppDbContext context) : base(context)
    {
    }
}