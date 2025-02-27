using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using seaplan.data.Context;
using seaplan.entity.Entities.Common;

namespace seaplan.data.Repository.Concrete;

public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context;

    public ReadRepository(AppDbContext context)
    {
        _context = context;
    }

    private DbSet<T> Table => _context.Set<T>();

    public IQueryable<T> GetAll(bool tracking = true)
    {
        var query = tracking ? Table.AsQueryable() : Table.AsNoTracking();
        return query;
    }

    public async Task<T> GetById(string id, bool tracking = true)
    {
        var query = tracking ? Table.AsQueryable() : Table.AsNoTracking();
        return await query.FirstOrDefaultAsync(a => a.Id == Guid.Parse(id));
    }

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query = tracking ? Table.AsQueryable() : Table.AsNoTracking();

        return await query.FirstOrDefaultAsync(method);
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
    {
        var query = tracking ? Table.AsQueryable() : Table.AsNoTracking();
        return query.Where(method);
    }
}