using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebAPiDemo.Entities;

namespace WebApiDemo.Abstractions.Repository;
public interface IItemEntityRepository
{
    Task<IEnumerable<ItemEntity>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<ItemEntity> GetByIdAsync(Guid ownerId, CancellationToken cancellationToken = default);

    Task InsertAsync(ItemEntity owner);

    Task RemoveAsync(ItemEntity owner);
}
