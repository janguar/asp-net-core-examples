using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDemo.Domain.Entities;
using WebApiDemo.DTO;

namespace WebApiDemo.Services.Abstraction
{
    public interface IItemService
    {
        Task<IEnumerable<ItemEntity>> GetAllAsync(
            CancellationToken cancellationToken = default
        );

        Task<ItemEntity> GetByIdAsync(
            Guid ownerId,
            CancellationToken cancellationToken = default);

        Task<ItemEntity> CreateAsync(
            ItemEntityFroCreateDto ownerForCreationDto,
            CancellationToken cancellationToken = default);

        Task UpdateAsync(
            Guid ownerId,
            ItemEntityForUpdatesDto ownerForUpdateDto,
            CancellationToken cancellationToken = default);

        Task DeleteAsync(
            Guid ownerId,
            CancellationToken cancellationToken = default);

    }
}
