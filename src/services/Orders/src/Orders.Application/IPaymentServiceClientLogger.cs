namespace Orders.Application;

/// <summary>
/// Minimal logging abstraction for PaymentServiceClient (configuration demo).
/// </summary>
public interface IPaymentServiceClientLogger
{
    void LogInitialized(Uri? baseUrl, TimeSpan timeout);
    void LogCalling(Uri? baseUrl, Guid orderId);
}
