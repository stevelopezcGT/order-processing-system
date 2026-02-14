namespace Orders.Application.Contracts.Items;

public record AddItemToOrderRequest(Guid OrderId, string ProductId, int Quantity, decimal UnitPrice);
