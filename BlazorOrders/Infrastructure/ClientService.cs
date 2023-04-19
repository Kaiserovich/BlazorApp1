using BlazorOrders.Contracts;
using BlazorOrders.Entities.Enumerations;
using BlazorOrders.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace BlazorOrders.Infrastructure
{
    public class ClientService : IClientService
    {
        private readonly IRepositoryWrapper _repository;
        private readonly ILoggerManager _logger;
        public ClientService(IRepositoryWrapper repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<List<Client>> GetAllClientsAsync()
        {
            try
            {
                _logger.LogDebug($"Geting All Clients");

                return await _repository.Client.FindAll().ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong inside {MethodBase.GetCurrentMethod()} action: {ex.Message}");
                return null;
            }
        }

        public async Task<List<Client>> GetClientsByStatusAsync(ClientStatus status)
        {
            try
            {
                _logger.LogDebug($"Geting Clients with status:{status}");

                return await _repository.Client.FindAll()
                    .Where(x => x.Status == status)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside {MethodBase.GetCurrentMethod()} action: {ex.Message}");
                return null;
            }
        }
        public async Task<Client> GetClientByIdAsync(int id)
        {
            try
            {
                _logger.LogDebug($"Geting Client with ID:{id}");

                return await _repository.Client.FindByCondition(a => a.Id.Equals(id))
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside {MethodBase.GetCurrentMethod()} action: {ex.Message}");
                return null;
            }
        }

        public async Task CreateClientAsync(Client client)
        {
            try
            {
                client.DataCreate = DateTime.Now;
                client.Status = 0;

                _logger.LogDebug($"Creating client:{JsonConvert.SerializeObject(client)}");

                _repository.Client.CreateClient(client);
                await _repository.SaveAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside {MethodBase.GetCurrentMethod()} action: {ex.Message}");
            }
        }
        public string UpadateClient(Client client)
        {
            try
            {
                if (client.Status == ClientStatus.Inactive && _repository.Order.GetOrdersByClientId(client.Id).Where(order => order.Status == OrderStatus.New).Count() != 0)
                {
                    string message = $"The client (ID:{client.Id}) has orders in a new status. So the client's status hasn't changed";

                    _logger.LogDebug(message);

                    return message;
                }
                else
                {
                    _logger.LogDebug($"Updating client:{JsonConvert.SerializeObject(client)}");

                    _repository.Client.Update(client);
                    _repository.SaveAsync();

                    return string.Empty;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside {MethodBase.GetCurrentMethod()} action: {ex.Message}");
                return ex.Message;
            }
        }
        public void DeleteClient(Client client)
        {
            try
            {
                _logger.LogDebug($"Deleting client:{JsonConvert.SerializeObject(client)}");

                _repository.Client.Delete(client);
                _repository.SaveAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside {MethodBase.GetCurrentMethod()} action: {ex.Message}");
            }
        }
    }
}
