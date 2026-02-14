using Orders.Domain;

namespace Orders.Application.Abstractions;

public interface IOrderRepository
{
    Task AddAsync(Order order);
    Task<Order?> GetByIdAsync(Guid id);
}
