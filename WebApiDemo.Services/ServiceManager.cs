using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiDemo.Services.Abstraction;
using WebAPiDemo.Domain.Repositories;

namespace WebApiDemo.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IItemService> _lazyOwnerService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _lazyOwnerService = new Lazy<IItemService>(() => new ItemService(repositoryManager));
        }

        public IItemService OwnerService => _lazyOwnerService.Value;

    }
}
