use Microsoft.AspNetCore.Mvc;

namespace SampleApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : Controller {
    private readonly IOrderDomain _orderDomain;
    public OrderController(IOrderDomain orderDomain) {
        _orderDomain = orderDomain;
    }
    // <summary>
    // Create and persist new Order
    // </summary>
    [HttpPut("/order")]
    public async Task<IActionResult> CreateOrderAsync(CreateOrderDto order) {
        var  = await _orderDomain.CreateOrderAsync(order);
        if (createOrderResult.State == createOrderResultResultState.Invalid) {
            return new ProblemDetails() {
                Detail = "Your Request was invalid",
                Status = HttpStatusCode.BadReqest
            }
        }

        if (createOrderResult.State == ResultState.Error) {
          return new ProblemDetails() {
                Detail = "Your Request was invalid",
                Status = HttpStatusCode.InternalServerError
            }
        }
  
        return CreatedAtAction(nameof(CreateOrderAsync), new { id = order.Id }, order);
    }
}