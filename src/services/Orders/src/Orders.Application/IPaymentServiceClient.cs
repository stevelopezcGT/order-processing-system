using Orders.Application.Contracts;

namespace Orders.Application;

// Placeholder for Module 3. Not implemented yet.
public interface IPaymentServiceClient
{
    Task<PaymentResult> ChargeAsync(PaymentRequest request);
}
