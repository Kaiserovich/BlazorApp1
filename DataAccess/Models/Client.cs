using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    [Table(nameof(Client))]
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DataCreate { get; set; }
        public string Status { get; set; }
        public IEnumerable<Order>? Orders { get; set; }
    }
}
