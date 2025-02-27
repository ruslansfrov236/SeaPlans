using seaplan.data.Context;
using seaplan.entity.Entities;

namespace seaplan.data.Repository.Concrete;

public class ProductImagesReadRepository : ReadRepository<ProductImages>, IProductImagesReadRepository
{
    public ProductImagesReadRepository(AppDbContext context) : base(context)
    {
    }
}