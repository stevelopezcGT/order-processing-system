using Microsoft.Extensions.Logging;
using Orders.Application;
using Orders.Infrastructure.ExternalServices;

namespace Orders.HttpApi;

internal sealed class PaymentServiceClientLogger : IPaymentServiceClientLogger
{
    private readonly ILogger<PaymentServiceClient> _logger;

    public PaymentServiceClientLogger(ILogger<PaymentServiceClient> logger)
    {
        _logger = logger;
    }

    public void LogInitialized(Uri? baseUrl, TimeSpan timeout)
    {
        _logger.LogInformation(
            "PaymentServiceClient initialized with BaseUrl: {BaseUrl} and Timeout: {Timeout}",
            baseUrl,
            timeout);
    }

    public void LogCalling(Uri? baseUrl, Guid orderId)
    {
        _logger.LogInformation(
            "Calling Payment service at {BaseUrl} for OrderId {OrderId}",
            baseUrl,
            orderId);
    }
}
