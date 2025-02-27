using seaplan.data.Context;
using seaplan.entity;

namespace seaplan.data.Repository.Concrete;

public class SliderReadRepository : ReadRepository<Slider>, ISliderReadRepository
{
    public SliderReadRepository(AppDbContext context) : base(context)
    {
    }
}