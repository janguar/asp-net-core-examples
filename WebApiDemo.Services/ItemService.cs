namespace WebApiDemo.Services;
public class ItemService //: IItemService
{
    //private readonly IRepositoryManager _repositoryManager;

    //public ItemService(IRepositoryManager repositoryManager)
    //{
    //    _repositoryManager = repositoryManager;
    //}

    //public async Task<ItemEntity> CreateAsync(ItemEntityFroCreateDto ownerForCreationDto, CancellationToken cancellationToken = default)
    //{
    //    var owner = ownerForCreationDto.Adapt<ItemEntity>();

    //    _repositoryManager.ItemRepository.Insert(owner);

    //    int result =  await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

    //    return owner.Adapt<ItemEntityDto>();
    //}

    //public Task DeleteAsync(Guid ownerId, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    //public Task<IEnumerable<ItemEntity>> GetAllAsync(CancellationToken cancellationToken = default) => throw new NotImplementedException();
    //public Task<ItemEntity> GetByIdAsync(Guid ownerId, CancellationToken cancellationToken = default) => throw new NotImplementedException();
    //public Task UpdateAsync(Guid ownerId, ItemEntityForUpdatesDto ownerForUpdateDto, CancellationToken cancellationToken = default) => throw new NotImplementedException();
}
