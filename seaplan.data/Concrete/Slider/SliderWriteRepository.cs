using seaplan.data.Context;
using seaplan.entity;

namespace seaplan.data.Repository.Concrete;

public class SliderWriteRepository : WriteRepository<Slider>, ISliderWriteRepository
{
    public SliderWriteRepository(AppDbContext context) : base(context)
    {
    }
}