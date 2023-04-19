using BlazorOrders.Entities.Enumerations;
using BlazorOrders.Entities.Models;

namespace BlazorOrders.Entities.DataTransferObject
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DataCreate { get; set; }
        public ClientStatus Status { get; set; }
        public IEnumerable<OrderDTO>? Orders { get; set; }
    }
}
