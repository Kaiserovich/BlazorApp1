using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorOrders.Entities.Models
{
    [Table(nameof(SecurityToken))]
    public class SecurityToken
    {
        public string UserName { get; set; }
        public string AccessToken { get; set; }
        public DateTime ExpitedAt { get; set; }
    }
}
