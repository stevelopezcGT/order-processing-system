namespace Orders.Application.Contracts.Orders;

public record CreateOrderResponse(Guid OrderId, bool Success, string? Error);
