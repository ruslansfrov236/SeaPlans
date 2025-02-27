using seaplan.data.Context;
using seaplan.entity.Entities;

namespace seaplan.data.Repository.Concrete;

public class MessagesWriteRepository : WriteRepository<Messages>, IMessagesWriteRepository
{
    public MessagesWriteRepository(AppDbContext context) : base(context)
    {
    }
}