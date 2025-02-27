using seaplan.data.Context;
using seaplan.entity.Entities;

namespace seaplan.data.Repository.Concrete;

public class OrderItemReadRepository : ReadRepository<OrderItem>, IOrderItemReadRepository
{
    public OrderItemReadRepository(AppDbContext context) : base(context)
    {
    }
}