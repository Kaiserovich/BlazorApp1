using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorOrders.Entities.Enumerations;

namespace BlazorOrders.Entities.Models
{
    [Table(nameof(Client))]
    public class Client
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]    
        public string Name { get; set; }
        [Required]
        [Display(Name="Create Data")]
        public DateTime DataCreate { get; set; }
        [Required]
        public ClientStatus Status { get; set; }
        public IEnumerable<Order>? Orders { get; set; }
    }
}
