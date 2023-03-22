using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Entities.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Decription { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
        public OrderStatus Status { get; set; }
        public int CurrencyId { get; set; }

        public int ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; }


    }
}
