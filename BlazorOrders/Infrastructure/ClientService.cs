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
                _logger.LogInfo($"Fetching all the Clients from the storage");

                List<Client> clients = await _repository.Client.FindAll().ToListAsync();

                _logger.LogInfo($"Returning {clients.Count} clients");

                return clients;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside {MethodBase.GetCurrentMethod()} action: {ex.Message}");
                return null;
            }
        }

        public async Task<List<Client>> GetClientsByStatusAsync(ClientStatus status)
        {
            try
            {
                _logger.LogInfo($"Fetching clients with status:{status} from the storage");

                List<Client> clients = await _repository.Client.FindAll()
                    .Where(x => x.Status == status)
                    .ToListAsync();

                _logger.LogInfo($"Returning {clients.Count} clients");

                return clients;
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
                _logger.LogInfo($"Fetching client with ID:{id} from the storage");

                Client client = await _repository.Client.FindByCondition(a => a.Id.Equals(id))
                    .FirstOrDefaultAsync();

                _logger.LogInfo($"Returning clients");

                return client;
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
                _logger.LogInfo($"Creating client:{JsonConvert.SerializeObject(client)}");

                client.DataCreate = DateTime.Now;
                client.Status = 0;

                _repository.Client.CreateClient(client);
                await _repository.SaveAsync();

                _logger.LogInfo($"Successful creation of a new client");

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
                _logger.LogInfo($"Updating client:{JsonConvert.SerializeObject(client)}");

                if (client.Status == ClientStatus.Inactive && _repository.Order.GetOrdersByClientId(client.Id).Where(order => order.Status == OrderStatus.New).Count() != 0)
                {
                    string message = $"The client (ID:{client.Id}) has orders in a new status. So the client's status hasn't changed";

                    _logger.LogInfo(message);

                    return message;
                }
                else
                {
                    _repository.Client.Update(client);
                    _repository.SaveAsync();

                    _logger.LogInfo($"Successful client update");

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
                _logger.LogInfo($"Deleting client:{JsonConvert.SerializeObject(client)}");

                _repository.Client.Delete(client);
                _repository.SaveAsync();

                _logger.LogInfo($"Successful client deletion");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside {MethodBase.GetCurrentMethod()} action: {ex.Message}");
            }
        }
    }
}
