using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPiDemo.Domain.Repositories;
public interface IRepositoryManager
{
    IItemRepository ItemRepository { get; }

    IUnitOfWork UnitOfWork { get; }
}