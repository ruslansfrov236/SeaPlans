namespace seaplan.data.Repository.Concrete;

public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
{
    public CategoryReadRepository(AppDbContext context) : base(context)
    {
    }
}