using seaplan.data.Context;
using seaplan.entity.Entities;

namespace seaplan.data.Repository.Concrete;

public class PaymentDetailsReadRepository : ReadRepository<PaymentDetails>, IPaymentDetailsReadRepository
{
    public PaymentDetailsReadRepository(AppDbContext context) : base(context)
    {
    }
}