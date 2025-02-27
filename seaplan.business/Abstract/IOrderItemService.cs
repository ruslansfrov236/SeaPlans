using seaplan.entity.Entities;

namespace seaplan.business.Abstract;

public interface IOrderItemService
{
    Task<List<OrderItem>> GetOrderComponents();
    Task<OrderItem> GetOrderComponentById(string id);
    Task<bool> Delete(string id);
    Task<bool> Create(string id);
}