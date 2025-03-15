namespace seaplan.business.Abstract;

public interface IFacilitiesService
{
    Task<List<Facilities>> GetAll();
    Task<Facilities> GetById(string id);
    Task<bool> Create(CreateFacilitiesVM model);
    Task<bool> Update(UpdateFacilitiesVM model);
    Task<bool> Delete(string id);
}