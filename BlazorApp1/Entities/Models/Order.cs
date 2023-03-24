using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlazorApp1.Entities.Enumerations;

namespace BlazorApp1.Entities.Models
{
    public class Order
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Decription { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        [Display(Name= "Currency ID")]
        public int CurrencyId { get; set; }

        [Required]
        [Display(Name= "Client ID")]
        public int ClientId { get; set; }
        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; }


    }
}
