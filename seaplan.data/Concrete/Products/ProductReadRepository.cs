using seaplan.data.Context;
using seaplan.entity.Entities;

namespace seaplan.data.Repository.Concrete;

public class ProductReadRepository : ReadRepository<Products>, IProductReadRepository
{
    public ProductReadRepository(AppDbContext context) : base(context)
    {
    }
}