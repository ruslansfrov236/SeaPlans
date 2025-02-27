using seaplan.business.Abstract;
using seaplan.entity.Entities;

namespace seaplan.business.Concrete;

public class OrderItemService : IOrderItemService
{
    public Task<List<OrderItem>> GetOrderComponents()
    {
        throw new NotImplementedException();
    }

    public Task<OrderItem> GetOrderComponentById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(string id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Create(string id)
    {
        throw new NotImplementedException();
    }
}