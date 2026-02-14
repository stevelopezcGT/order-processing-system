namespace Orders.HttpApi;

/// <summary>
/// Configuration for the Payment service HTTP client.
/// Can be overridden via environment variables: PaymentService__BaseUrl, PaymentService__TimeoutSeconds.
/// </summary>
public class PaymentServiceOptions
{
    public const string SectionName = "PaymentService";

    public string BaseUrl { get; set; } = "http://localhost:5005";
    public int TimeoutSeconds { get; set; } = 5;
}
