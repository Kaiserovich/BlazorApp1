using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Entities.Models
{
    [Table(nameof(Client))]
    public class Client
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]    
        public string Name { get; set; }
        public DateTime DataCreate { get; set; }
        public ClientStatus Status { get; set; }
        public IEnumerable<Order>? Orders { get; set; }
    }
}
