using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebApiDemo.Abstractions;
public interface IRepositoryManager
{
    IItemEntityRepository ItemRepository { get; }

    IUnitOfWork UnitOfWork { get; } 
}