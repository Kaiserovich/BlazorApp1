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
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly ILoggerManager _logger;
        public ClientService(IRepositoryWrapper repoWrapper, ILoggerManager logger)
        {
            _repoWrapper = repoWrapper;
            _logger = logger;
        }
        public async Task<List<Client>> GetAllClientsAsync()
        {
            _logger.LogDebug($"Geting All Clients");

            return await _repoWrapper.Client.FindAll().ToListAsync();
        }

        public async Task<List<Client>> GetClientsByStatusAsync(ClientStatus status)
        {
            _logger.LogDebug($"Geting Clients with status:{status}");

            return await _repoWrapper.Client.FindAll().Where(x => x.Status == status).ToListAsync();
        }
        public async Task<Client> GetClientByIdAsync(int id)
        {
            _logger.LogDebug($"Geting Client with ID:{id}");

            return await _repoWrapper.Client.FindByCondition(a => a.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task CreateClientAsync(Client client)
        {
            client.DataCreate = DateTime.Now;
            client.Status = 0;

            _logger.LogDebug($"Creating client:{JsonConvert.SerializeObject(client)}");

            _repoWrapper.Client.CreateClient(client);
            await _repoWrapper.SaveAsync();
        }
        public string UpadateClient(Client client)
        {
            if (client.Status == ClientStatus.Inactive && _repoWrapper.Order.GetOrdersByClientId(client.Id).Where(order => order.Status == OrderStatus.New).Count() != 0)
            {
                string message = $"The client (ID:{client.Id}) has orders in a new status. So the client's status hasn't changed";

                _logger.LogDebug(message);

                return message;
            }
            else
            {
                _logger.LogDebug($"Updating client:{JsonConvert.SerializeObject(client)}");

                _repoWrapper.Client.Update(client);
                _repoWrapper.SaveAsync();

                return string.Empty;
            }
        }
        public void DeleteClient(Client client)
        {
            _logger.LogDebug($"Deleting client:{JsonConvert.SerializeObject(client)}");

            _repoWrapper.Client.Delete(client);
            _repoWrapper.SaveAsync();
        }
    }
}
