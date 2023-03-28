using BlazorOrders.Entities.Models;
using System.Linq.Expressions;

namespace BlazorOrders.Contracts
{
    public interface IRepositoryWrapper
    {
        IOrderRepository Order { get; }
        IClientRepository Client { get; }
        Task SaveAsync();
    }
}
