using BlazorOrders.Entities.Enumerations;

namespace BlazorOrders.Entities.DataTransferObject
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string Decription { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
        public OrderStatus Status { get; set; }
        public CurrencyType Currency { get; set; }
        public int ClientId { get; set; }
    }
}
