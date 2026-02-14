using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Orders.Application;
using Orders.Application.Abstractions;
using Orders.Application.UseCases;
using Orders.HttpApi;
using Orders.Infrastructure.ExternalServices;
using Orders.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<OrdersDbContext>(options =>
    options.UseInMemoryDatabase("OrdersDb"));
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<CreateOrderUseCase>();

// Configuration: appsettings.json and appsettings.Development.json loaded by default.
// Environment variables (e.g. PaymentService__BaseUrl, PaymentService__TimeoutSeconds) override.
builder.Services.Configure<PaymentServiceOptions>(
    builder.Configuration.GetSection(PaymentServiceOptions.SectionName));

builder.Services.AddSingleton<IPaymentServiceClientLogger, PaymentServiceClientLogger>();
builder.Services.AddHttpClient<IPaymentServiceClient, PaymentServiceClient>((sp, client) =>
{
    var config = sp.GetRequiredService<IOptions<PaymentServiceOptions>>().Value;
    client.BaseAddress = new Uri(config.BaseUrl);
    client.Timeout = TimeSpan.FromSeconds(config.TimeoutSeconds);
});

builder.Services.AddHealthChecks();
builder.Services.AddControllers();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();

// Log resolved PaymentService config so env vars (e.g. PaymentService__BaseUrl) can be verified
var paymentOpts = app.Services.GetRequiredService<IOptions<PaymentServiceOptions>>().Value;
app.Logger.LogInformation("PaymentService resolved config: BaseUrl={BaseUrl}, TimeoutSeconds={TimeoutSeconds}", paymentOpts.BaseUrl, paymentOpts.TimeoutSeconds);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapHealthChecks("/health");
app.MapControllers();

app.Run();
