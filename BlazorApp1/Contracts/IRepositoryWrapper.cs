using BlazorApp1.Entities.Models;
using System.Linq.Expressions;

namespace BlazorApp1.Contracts
{
    public interface IRepositoryWrapper
    {
        IOrderRepository Order { get; }
        IClientRepository Client { get; }
        Task SaveAsync();
    }
}
