using seaplan.data.Context;
using seaplan.entity.Entities;

namespace seaplan.data.Repository.Concrete;

public class ContactReadRepository : ReadRepository<Contact>, IContactReadRepository
{
    public ContactReadRepository(AppDbContext context) : base(context)
    {
    }
}