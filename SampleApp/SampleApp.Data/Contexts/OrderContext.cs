using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models;

public class OrderContext : DbContext
{
    public TodoContext(DbContextOptions<OrderContext> options)
        : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; } = null!;
}