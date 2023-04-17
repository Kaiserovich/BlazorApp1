using BlazorOrders.Contracts;
using BlazorOrders.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BlazorOrders.Infrastructure
{
    public class OrderService : IOrderService
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly ILoggerManager _logger;
        public OrderService(IRepositoryWrapper repoWrapper, ILoggerManager logger)
        {
            _repoWrapper = repoWrapper;
            _logger = logger;
        }
        public async Task<List<Order>> GetAllOrdersAsync()
        {
            _logger.LogDebug($"Geting All Order");

            return await _repoWrapper.Order.FindAll().ToListAsync();
        }

        public List<Order> GetOrdersByClientId(int clientId)
        {
            _logger.LogDebug($"Geting Orders with Client ID:{clientId}");

            return _repoWrapper.Order.FindByCondition(a => a.ClientId.Equals(clientId)).ToList();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            _logger.LogDebug($"Geting Order with ID:{id}");

            return await _repoWrapper.Order.FindByCondition(a => a.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<Order> GetLastOrdersAsync()
        {
            _logger.LogDebug($"Geting Last Order");

            return await _repoWrapper.Order.FindAll().LastOrDefaultAsync();
        }
        public async Task CreateOrderAsync(Order order)
        {
            order.Status = 0;
            order.Date = DateTime.Now;

            _logger.LogDebug($"Creating order:{JsonConvert.SerializeObject(order)}");

            _repoWrapper.Order.Create(order);
            await _repoWrapper.SaveAsync();
        }
        public void UpadateOrder(Order order)
        {
            _logger.LogDebug($"Updating order:{JsonConvert.SerializeObject(order)}");

            _repoWrapper.Order.Update(order);
            _repoWrapper.SaveAsync();
        }
        public void DeleteOrder(Order order)
        {
            _logger.LogDebug($"Deleting order:{JsonConvert.SerializeObject(order)}");

            _repoWrapper.Order.Delete(order);
            _repoWrapper.SaveAsync();
        }
    }
}
