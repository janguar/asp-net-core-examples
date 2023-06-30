using WebApiDemo.Services.Abstraction;

namespace WebApiDemo.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IItemService> _lazyOwnerService;

        //public ServiceManager(IRepositoryManager repositoryManager)
        //{
        //    _lazyOwnerService = new Lazy<IItemService>(() => new ItemService(repositoryManager));
        //}

        public IItemService OwnerService => _lazyOwnerService.Value;

    }
}
