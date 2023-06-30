using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using WebApiDemo.Domain.Entities;

namespace WebAPiDemo.Domain.Repositories;
public interface IItemRepository
{
    Task<IEnumerable<ItemEntity>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<ItemEntity> GetByIdAsync(Guid ownerId, CancellationToken cancellationToken = default);

    void Insert(ItemEntity owner);

    void Remove(ItemEntity owner);
}