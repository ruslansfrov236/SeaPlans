using seaplan.data.Context;
using seaplan.entity.Entities;

namespace seaplan.data.Repository.Concrete;

public class MessagesReadRepository : ReadRepository<Messages>, IMessagesReadRepository
{
    public MessagesReadRepository(AppDbContext context) : base(context)
    {
    }
}