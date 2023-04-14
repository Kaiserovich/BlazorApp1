using BlazorOrders.Contracts;
using BlazorOrders.Entities.Enumerations;
using BlazorOrders.Entities.Models;
using Microsoft.EntityFrameworkCore;
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
            // _logger.LogInfo($"Call GetAllClientsAsync{MethodBase.GetCurrentMethod().Name}");
             _logger.LogInfo($"Call GetAllClientsAsync");
            return await _repoWrapper.Client.FindAll().ToListAsync();
        }

        public async Task<List<Client>> GetClientsByStatusAsync(ClientStatus status) => await _repoWrapper.Client.FindAll().Where(x => x.Status == status).ToListAsync();
        public async Task<Client> GetClientByIdAsync(int id) => await _repoWrapper.Client.FindByCondition(a => a.Id.Equals(id)).FirstOrDefaultAsync();
        public async Task CreateClientAsync(Client client)
        {
            client.DataCreate = DateTime.Now;
            client.Status = 0;

            _repoWrapper.Client.CreateClient(client);
            await _repoWrapper.SaveAsync();
        }
        public string UpadateClient(Client client)
        {
            _logger.LogInfo($"Call GetAllClientsAsync");

            if (client.Status == ClientStatus.Inactive && _repoWrapper.Order.GetOrdersByClientId(client.Id).Where(order => order.Status == OrderStatus.New).Count() != 0)
                return $"The client has orders in a new status. So the client's status be changed";
            else
            {
                _repoWrapper.Client.Update(client);
                _repoWrapper.SaveAsync();

                return string.Empty;
            }
        }
        public void DeleteClient(Client client)
        {
            _repoWrapper.Client.Delete(client);
            _repoWrapper.SaveAsync();
        }
    }
}
