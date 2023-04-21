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
                _logger.LogInfo($"Fetching all the orders from the storage");

                List<Order> orders = await _repository.Order.FindAll().ToListAsync();

                _logger.LogInfo($"Returning {orders.Count} orders");

                return orders;
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
                _logger.LogInfo($"Fetching the orders with Client ID:{clientId} from the storage");

                List<Order> orders = _repository.Order.FindByCondition(a => a.ClientId.Equals(clientId)).ToList();

                _logger.LogInfo($"Returning {orders.Count} orders");

                return orders;
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
                _logger.LogInfo($"Fetching order with ID:{id} from the storage");

                Order order = await _repository.Order.FindByCondition(a => a.Id.Equals(id))
                    .FirstOrDefaultAsync();

                _logger.LogInfo($"Returning order");

                return order;
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
                _logger.LogInfo($"Fetching last order from the storage");

                Order order = await _repository.Order.FindAll()
                    .LastOrDefaultAsync();

                _logger.LogInfo($"Successfully fetching");

                return order;
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

                _logger.LogInfo($"Successful creation of a new order");

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

                _logger.LogInfo($"Successful order update");
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

                _logger.LogInfo($"Successful order deletion");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside {MethodBase.GetCurrentMethod()} action: {ex.Message}");
            }
        }
    }
}
