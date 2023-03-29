using BlazorOrders.Contracts;
using BlazorOrders.Entities;

namespace BlazorOrders.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private AppDbContext _repoContext;
        private IClientRepository _client;
        private IOrderRepository _order;
        public IClientRepository Client
        {
            get
            {
                if (_client == null)
                    _client = new ClientRepository(_repoContext);
                return _client;
            }
        }
        public IOrderRepository Order
        {
            get
            {
                if (_order == null)
                    _order = new OrderRepository(_repoContext);
                return _order;
            }
        }
        public RepositoryWrapper(AppDbContext repositoryContext) => _repoContext = repositoryContext;
        public async Task SaveAsync() => await _repoContext.SaveChangesAsync();
    }
}
