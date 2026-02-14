using Microsoft.EntityFrameworkCore;
using Orders.Domain;

namespace Orders.Infrastructure.Persistence;

public class OrdersDbContext : DbContext
{
    public OrdersDbContext(DbContextOptions<OrdersDbContext> options)
        : base(options)
    {
    }

    public DbSet<Order> Orders => Set<Order>();
}
