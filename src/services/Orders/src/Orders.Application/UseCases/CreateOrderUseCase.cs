using Orders.Application;
using Orders.Application.Abstractions;
using Orders.Application.Contracts;
using Orders.Application.Contracts.Orders;
using Orders.Domain;

namespace Orders.Application.UseCases;

public class CreateOrderUseCase
{
    private readonly IOrderRepository _repository;
    private readonly IPaymentServiceClient _paymentService;

    public CreateOrderUseCase(IOrderRepository repository, IPaymentServiceClient paymentService)
    {
        _repository = repository;
        _paymentService = paymentService;
    }

    public async Task<CreateOrderResponse> ExecuteAsync(CreateOrderRequest request)
    {
        var order = new Order(100); // fixed amount for MVP

        await _repository.AddAsync(order);

        var paymentResult = await _paymentService.ChargeAsync(
            new PaymentRequest(order.Id, order.Amount, "USD"));

        if (!paymentResult.Success)
            return new CreateOrderResponse(order.Id, false, paymentResult.Error);

        return new CreateOrderResponse(order.Id, true, null);
    }
}
