using Orders.Domain;
using Xunit;

namespace Orders.Domain.Tests;

public class OrderTests
{
    [Fact]
    public void New_Order_Starts_As_Created()
    {
        // Arrange & Act
        var order = new Order(100.00m);

        // Assert
        Assert.Equal(OrderStatus.Created, order.Status);
    }

    [Fact]
    public void Order_Cannot_Be_Paid_Twice()
    {
        // Arrange
        var order = new Order(100.00m);
        order.Pay();

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => order.Pay());
    }
}
