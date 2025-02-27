using seaplan.entity.Entities.Common;

namespace seaplan.data.Repository;

public interface IWriteRepository<T> where T : BaseEntity
{
    Task<bool> AddAsync(T model);
    Task<bool> RemoveAsync(string id);
    bool Remove(T model);
    bool Update(T model);
    Task<int> SaveAsync();
}