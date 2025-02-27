using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using seaplan.business.Abstract;
using seaplan.business.ViewsModels;
using seaplan.business.ViewsModels.Reservations;
using seaplan.data.Repository;
using seaplan.entity.Entities;
using seaplan.entity.Entities.Enum;
using seaplan.entity.Entities.Identity;

namespace seaplan.business.Concrete;

public class ReservationServices : IReservationServices
{
    private readonly IExtraServiceReadRepository _extraServiceReadRepository;
    private readonly IExtraServiceWriteRepository _extraServiceWriteRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IReservationReadRepository _reservationReadRepository;
    private readonly IReservationWriteRepository _reservationWriteRepository;
    private readonly UserManager<AppUser> _userManager;

    public ReservationServices(IReservationReadRepository reservationReadRepository,
        IReservationWriteRepository reservationWriteRepository, IExtraServiceReadRepository extraServiceReadRepository,
        IExtraServiceWriteRepository extraServiceWriteRepository, IHttpContextAccessor httpContextAccessor,
        UserManager<AppUser> userManager)
    {
        _reservationReadRepository = reservationReadRepository;
        _reservationWriteRepository = reservationWriteRepository;
        _extraServiceReadRepository = extraServiceReadRepository;
        _extraServiceWriteRepository = extraServiceWriteRepository;
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
    }

    public async Task<List<Reservation>> Filter(FilterReservationVM model)
    {
        IQueryable<Reservation> query = _reservationReadRepository.GetAll().Include(a => a.Order)
            .Include(a => a.Product)
            .Include(a => a.ExtraServices);


        if (model != null)
        {
            query = query.Where(pr =>
                (model.CheckIn != null ? pr.CheckIn >= model.CheckIn : true) &&
                (model.CheckOut != null ? pr.CheckOut <= model.CheckOut : true));
            query = query.Where(pr => model.Rooms != null ? pr.Rooms == model.Rooms : true);
            query = query.Where(pr => model.Children != null ? pr.Children == model.Children : true);
            query = query.Where(pr => model.Adults != null ? pr.Adults == model.Adults : true);
        }

        return await query.ToListAsync();
    }

    public Task<List<Reservation>> SearchFilter(string search)
    {
        var values = _reservationReadRepository
            .GetWhere(a =>
                a.RezervationCode.Contains(search.ToLower().Trim())).ToListAsync();


        return values;
    }

    public async Task<bool> CheckIn(string id, Status status)
    {
        var rezervation = await _reservationReadRepository.GetById(id);


        rezervation.Status = status;


        _reservationWriteRepository.Update(rezervation);
        await _reservationWriteRepository.SaveAsync();
        return true;
    }

    public async Task<List<Reservation>> GetAll()
    {
        var values = await _reservationReadRepository.GetAll().Include(a => a.Order)
            .Include(a => a.Product)
            .Include(a => a.ExtraServices)
            .ToListAsync();
        return values;
    }

    public async Task<RezervatinExtralServicesVM> GetById(string id)
    {
        var values = await _reservationReadRepository.GetById(id);
        if (values == null) throw new Exception("Values is not found");

        var extraService = await _extraServiceReadRepository.GetWhere(a => a.ReservationId == values.Id).ToListAsync();

        var vm = new RezervatinExtralServicesVM
        {
            Reservations = values,
            ExtraServices = extraService
        };

        return vm;
    }

    public async Task<bool> Create(CreateReservationVM model)
    {
        var userName = _httpContextAccessor?.HttpContext?.User?.Identity?.Name;

        var user = await _userManager.Users.FirstOrDefaultAsync(a => a.UserName == userName);
        var reservation = new Reservation
        {
            RezervationCode = GenerateUniqueCode(),
            UserId = user.Id,
            Adults = model.Adults,
            Status = Status.Pending,
            CheckIn = model.CheckIn,
            CheckOut = model.CheckOut,
            Children = model.Children
        };
        await _reservationWriteRepository.AddAsync(reservation);
        await _reservationWriteRepository.SaveAsync();
        return true;
    }

    public async Task<bool> Update(UpdateReservationVM model)
    {
        var userName = _httpContextAccessor?.HttpContext?.User?.Identity?.Name;

        var user = await _userManager.Users.FirstOrDefaultAsync(a => a.UserName == userName);
        var values = await _reservationReadRepository.GetById(model.Id);
        if (values == null) throw new Exception("Values is not found");
        values.UserId = user.Id;
        values.Id = Guid.Parse(model.Id);
        values.Children = model.Children;
        values.CheckIn = model.CheckOut;
        values.CheckOut = model.CheckOut;
        values.Adults = model.Adults;
        values.Rooms = model.Rooms;
        values.Status = Status.Pending;
        _reservationWriteRepository.Update(values);
        await _reservationWriteRepository.SaveAsync();
        return true;
    }

    public async Task<bool> Delete(string id)
    {
        var values = await _reservationReadRepository.GetById(id);
        if (values == null) throw new Exception("Values is not found");

        _reservationWriteRepository.Remove(values);
        await _reservationWriteRepository.SaveAsync();
        return true;
    }

    private static string GenerateUniqueCode()
    {
        var random = new Random();
        return new string(Enumerable.Range(0, 10).OrderBy(x => random.Next()).Take(8).Select(x => x.ToString()[0])
            .ToArray());
    }
}