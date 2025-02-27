using seaplan.business.ViewsModels;
using seaplan.business.ViewsModels.Reservations;
using seaplan.entity.Entities;
using seaplan.entity.Entities.Enum;

namespace seaplan.business.Abstract;

public interface IReservationServices
{
    Task<List<Reservation>> Filter(FilterReservationVM model);
    Task<List<Reservation>> SearchFilter(string search);
    Task<bool> CheckIn(string id, Status status);
    Task<List<Reservation>> GetAll();
    Task<RezervatinExtralServicesVM> GetById(string id);
    Task<bool> Create(CreateReservationVM model);
    Task<bool> Update(UpdateReservationVM model);
    Task<bool> Delete(string id);
}