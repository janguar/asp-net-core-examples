namespace WebApiDemo.Services.Abstraction;
public interface IServiceManager
{
    IItemService OwnerService { get; }
}