using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorOrders.Entities.Models
{
    [Table(nameof(LoginUser))]
    public class LoginUser
    {
        [Required]
        [StringLength(50, ErrorMessage = "Too long")]    
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
