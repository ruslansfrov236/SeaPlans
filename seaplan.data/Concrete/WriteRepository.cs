using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using seaplan.data.Context;
using seaplan.entity.Entities.Common;

namespace seaplan.data.Repository.Concrete;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context;

    public WriteRepository(AppDbContext context)
    {
        _context = context;
    }

    private DbSet<T> Table => _context.Set<T>();

    public async Task<bool> AddAsync(T model)
    {
        EntityEntry<T> entity = await _context.AddAsync(model);

        return entity.State == EntityState.Added;
    }

    public async Task<bool> RemoveAsync(string id)
    {
        var model = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));

        return Remove(model);
    }

    public bool Remove(T model)
    {
        EntityEntry<T> entityEntry = _context.Remove(model);
        return entityEntry.State == EntityState.Deleted;
    }

    public bool Update(T model)
    {
        EntityEntry<T> entity = _context.Update(model);

        return entity.State == EntityState.Modified;
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}