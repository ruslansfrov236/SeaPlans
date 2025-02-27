using seaplan.data.Context;
using seaplan.entity.Entities;

namespace seaplan.data.Repository.Concrete;

public class ProductFacilitiesWriteRepository : WriteRepository<ProductFacilities>, IProductFacilitiesWriteRepository
{
    public ProductFacilitiesWriteRepository(AppDbContext context) : base(context)
    {
    }
}