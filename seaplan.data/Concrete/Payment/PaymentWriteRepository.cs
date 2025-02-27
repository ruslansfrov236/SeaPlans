using seaplan.data.Context;
using seaplan.entity.Entities;

namespace seaplan.data.Repository.Concrete;

public class PaymentWriteRepository : WriteRepository<Payment>, IPaymentWriteRepository
{
    public PaymentWriteRepository(AppDbContext context) : base(context)
    {
    }
}