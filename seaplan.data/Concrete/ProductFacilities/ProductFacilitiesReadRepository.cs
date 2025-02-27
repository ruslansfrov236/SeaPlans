using seaplan.data.Context;
using seaplan.entity.Entities;

namespace seaplan.data.Repository.Concrete;

public class ProductFacilitiesReadRepository : ReadRepository<ProductFacilities>, IProductFacilitiesReadRepository
{
    public ProductFacilitiesReadRepository(AppDbContext context) : base(context)
    {
    }
}