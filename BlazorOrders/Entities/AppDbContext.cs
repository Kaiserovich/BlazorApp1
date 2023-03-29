using BlazorOrders.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorOrders.Entities
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options): base(options) {}
        public DbSet<Client>? Clients { get; set; }
        public DbSet<Order>? Orders { get; set; }
    }
}
