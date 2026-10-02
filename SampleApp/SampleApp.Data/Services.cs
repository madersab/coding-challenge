using Microsoft.EntityFrameworkCore;

namespace SimpleApp.Data;

public static class DataServices
{
    public static AddDataServices(this IServiceCollection services) {
        services.AddDbContext<OrderContext>(opt => opt.UseInMemoryDatabase("Order"));
        services.AddDbContext<OrderItemContext>(opt => opt.UseInMemoryDatabase("OrderItem"));
    }
}