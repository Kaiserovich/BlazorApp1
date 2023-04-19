using BlazorOrders.Contracts;
using BlazorOrders.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Reflection;

namespace BlazorOrders.Infrastructure
{
    public class OrderService : IOrderService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly ILoggerManager _logger;
        public OrderService(IRepositoryWrapper repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<List<Order>> GetAllOrdersAsync()
        {
            try
            {
                _logger.LogDebug($"Geting All Order");

                return await _repository.Order.FindAll().ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside {MethodBase.GetCurrentMethod()} action: {ex.Message}");
                return null;
            }
        }
        public List<Order> GetOrdersByClientId(int clientId)
        {
            try
            {
                _logger.LogDebug($"Geting Orders with Client ID:{clientId} ");

                return _repository.Order.FindByCondition(a => a.ClientId.Equals(clientId)).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside {MethodBase.GetCurrentMethod()} action: {ex.Message}");
                return null;
            }
        }
        public async Task<Order> GetOrderByIdAsync(int id)
        {
            try
            {
                _logger.LogDebug($"Geting Order with ID:{id}");

                return await _repository.Order.FindByCondition(a => a.Id.Equals(id))
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside {MethodBase.GetCurrentMethod()} action: {ex.Message}");
                return null;
            }
        }
        public async Task<Order> GetLastOrdersAsync()
        {
            try
            {
                _logger.LogDebug($"Geting Last Order");

                return await _repository.Order.FindAll()
                    .LastOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside {MethodBase.GetCurrentMethod()} action: {ex.Message}");
                return null;
            }
        }
        public async Task CreateOrderAsync(Order order)
        {
            try
            {
                _logger.LogDebug($"Creating order:{JsonConvert.SerializeObject(order)}");

                order.Status = 0;
                order.Date = DateTime.Now;

                _repository.Order.Create(order);
                await _repository.SaveAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside {MethodBase.GetCurrentMethod()} action: {ex.Message}");
            }
        }
        public void UpadateOrder(Order order)
        {
            try
            {
                _logger.LogDebug($"Updating order:{JsonConvert.SerializeObject(order)}");

                _repository.Order.Update(order);
                _repository.SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside {MethodBase.GetCurrentMethod()} action: {ex.Message}");
            }
        }
        public void DeleteOrder(Order order)
        {
            try
            {
                _logger.LogDebug($"Deleting order:{JsonConvert.SerializeObject(order)}");

                _repository.Order.Delete(order);
                _repository.SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside {MethodBase.GetCurrentMethod()} action: {ex.Message}");
            }
        }
    }
}
