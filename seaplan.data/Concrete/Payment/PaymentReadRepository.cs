using seaplan.data.Context;
using seaplan.entity.Entities;

namespace seaplan.data.Repository.Concrete;

public class PaymentReadRepository : ReadRepository<Payment>, IPaymentReadRepository
{
    public PaymentReadRepository(AppDbContext context) : base(context)
    {
    }
}