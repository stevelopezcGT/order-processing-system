using Microsoft.AspNetCore.Mvc;
using Orders.Application.Contracts.Orders;
using Orders.Application.UseCases;

namespace Orders.HttpApi.Controllers;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly CreateOrderUseCase _useCase;

    public OrdersController(CreateOrderUseCase useCase)
    {
        _useCase = useCase;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderRequest request)
    {
        var result = await _useCase.ExecuteAsync(request);

        if (!result.Success)
            return BadRequest(result);

        return Ok(result);
    }
}
