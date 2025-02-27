

using seaplan.business.ViewsModels.Order;

namespace task.Webui.Services.Concrete;

public class OrderService:IOrderService
{
    public Task<List<Order>> GetOrderAsync()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Create(CreateOrderVM model)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(string id)
    {
        throw new NotImplementedException();
    }
}