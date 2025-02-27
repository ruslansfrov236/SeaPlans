using Microsoft.EntityFrameworkCore;
using seaplan.entity.Entities.Common;

namespace seaplan.data.Repository;

public interface IRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get; }
}