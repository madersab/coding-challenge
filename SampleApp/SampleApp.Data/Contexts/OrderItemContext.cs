using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models;

public class OrderItemContext : DbContext
{
    public TodoContext(DbContextOptions<OrderItemContext> options)
        : base(options)
    {
    }

    public DbSet<OrderItem> OrderItems { get; set; } = null!;
}