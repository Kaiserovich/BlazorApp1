using BlazorOrders.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BlazorOrders.Entities
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options): base(options) {}
        public DbSet<Client>? Clients { get; set; }
        public DbSet<Order>? Orders { get; set; }
    }
}
