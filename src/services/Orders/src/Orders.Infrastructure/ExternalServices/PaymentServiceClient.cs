using Orders.Application;
using Orders.Application.Contracts;

namespace Orders.Infrastructure.ExternalServices;

/// <summary>
/// HTTP client implementation for the Payment service. Simple placeholder call.
/// </summary>
public class PaymentServiceClient : IPaymentServiceClient
{
    private readonly HttpClient _httpClient;
    private readonly IPaymentServiceClientLogger _logger;

    public PaymentServiceClient(HttpClient httpClient, IPaymentServiceClientLogger logger)
    {
        _httpClient = httpClient;
        _logger = logger;
        _logger.LogInitialized(_httpClient.BaseAddress, _httpClient.Timeout);
    }

    public Task<PaymentResult> ChargeAsync(PaymentRequest request)
    {
        _logger.LogCalling(_httpClient.BaseAddress, request.OrderId);
        // Simple placeholder call.
        return Task.FromResult(new PaymentResult(true, Guid.NewGuid().ToString("N"), null));
    }
}
