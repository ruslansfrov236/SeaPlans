using seaplan.data.Context;
using seaplan.entity.Entities;

namespace seaplan.data.Repository.Concrete;

public class AboutHeaderWriteRepository : WriteRepository<AboutHeader>, IAboutHeaderWriteRepository
{
    public AboutHeaderWriteRepository(AppDbContext context) : base(context)
    {
    }
}