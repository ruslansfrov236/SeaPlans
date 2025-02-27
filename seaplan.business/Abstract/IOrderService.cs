using seaplan.business.ViewsModels.Order;
using seaplan.entity.Entities;

namespace seaplan.business.Abstract;

public interface IOrderService
{
    Task<List<Order>> GetOrderAsync();
    Task<bool> Create(CreateOrderVM model);
    Task<bool> Delete(string id);
}