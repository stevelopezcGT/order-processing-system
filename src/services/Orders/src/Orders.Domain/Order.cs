namespace Orders.Domain;

public class Order
{
    public Guid Id { get; private set; }
    public OrderStatus Status { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime CreatedAt { get; private set; }

    private Order()
    {
    }

    public Order(decimal amount)
    {
        Id = Guid.NewGuid();
        Status = OrderStatus.Created;
        Amount = amount;
        CreatedAt = DateTime.UtcNow;
    }

    public void Pay()
    {
        if (Status == OrderStatus.Paid)
        {
            throw new InvalidOperationException("An order can only be paid once.");
        }

        Status = OrderStatus.Paid;
    }
}
