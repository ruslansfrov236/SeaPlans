using System.Linq.Expressions;
using seaplan.entity.Entities.Common;

namespace seaplan.data.Repository;

public interface IReadRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll(bool tracking = true);
    Task<T> GetById(string id, bool tracking = true);
    Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);
    IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
}