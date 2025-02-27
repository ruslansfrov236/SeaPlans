using seaplan.data.Context;
using seaplan.entity.Entities;

namespace seaplan.data.Repository.Concrete;

public class ProductImagesWriteRepository : WriteRepository<ProductImages>, IProductImagesWriteRepository
{
    public ProductImagesWriteRepository(AppDbContext context) : base(context)
    {
    }
}