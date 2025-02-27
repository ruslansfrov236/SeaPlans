using seaplan.data.Context;
using seaplan.entity.Entities;

namespace seaplan.data.Repository.Concrete;

public class PaymentDetailsWriteRepository : WriteRepository<PaymentDetails>, IPaymentDetailsWriteRepository
{
    public PaymentDetailsWriteRepository(AppDbContext context) : base(context)
    {
    }
}