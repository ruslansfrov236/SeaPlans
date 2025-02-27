using seaplan.data.Context;
using seaplan.entity.Entities;

namespace seaplan.data.Repository.Concrete;

public class OrderItemWriteRepository : WriteRepository<OrderItem>, IOrderItemWriteRepository
{
    public OrderItemWriteRepository(AppDbContext context) : base(context)
    {
    }
}