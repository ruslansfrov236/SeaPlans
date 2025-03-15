using seaplan.business.ViewsModels.Slider;
using seaplan.entity;
using task.Webui.ViewsModels.Slider;

namespace seaplan.business.Abstract;

public interface ISliderService
{
    Task<List<Slider>> GetAll();
    Task<Slider> GetById(string id);
    Task<bool> Create(CreateSliderVM model);
    Task<bool> Update(UpdateSliderVM model);
    Task<bool> Delete(string id);
}