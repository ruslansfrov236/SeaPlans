using seaplan.data.Context;
using seaplan.entity.Entities;

namespace seaplan.data.Repository.Concrete;

public class ContactWriteRepository : WriteRepository<Contact>, IContactWriteRepository
{
    public ContactWriteRepository(AppDbContext context) : base(context)
    {
    }
}