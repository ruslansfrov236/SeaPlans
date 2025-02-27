using seaplan.data.Context;
using seaplan.entity.Entities;

namespace seaplan.data.Repository.Concrete;

public class ProductWriteRepository : WriteRepository<Products>, IProductWriteRepository
{
    public ProductWriteRepository(AppDbContext context) : base(context)
    {
    }
}