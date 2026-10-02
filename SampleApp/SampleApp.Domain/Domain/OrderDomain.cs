namespace SampleApp.Domain.Domain;

public class OrderDomain : IOrderDomain {
    private readonly IOrderItemDomain _orderItemDomain;
    private readonly OrderContext _orderContext;

    // TODO
    public OrderDomain(
        IOrderItemDomain orderItemDomain,
        OrderContext orderContext) {

        _orderItemDomain = orderItemDomain;
    }

    /// </inheritdoc>
    public Task<Result<CreateOrderDto>> CreateOrderAsync(CreateOrderDto orderDto) {
        if (!IsValid(orderDto)) {
            return new Result(orderDto, ResultState.Invalid);
        }


        // TODO: Map Order => evtl. Automapper oder Mapping-Helper#
        var order = new Order {
            CustomerId = orderDto.CustomerId
            RequiresApproval = orderDto.RequiresApproval
            Items = orderDto.Items, // TODO Map OrderItemDto to OrderItem!

        }

        // Save to Database
        var success = await _orderContext.SaveAsync(order);

        // Order Created Sucessfully 
        // Hinweis: evtl. success ein Object. Für diese Abfrage hier muss entsprechend der Status genutzt werden
        if (success) {
            return new Result(orderDto, ResultState.Success);
        } 

       return new Result(orderDto, ResultState.Invalid);
    }

    // Validate Order
    private bool IsValid(CreateOrderDto orderDto) {
        // At least one item per order is required; quantities must be > 0
        if (orderDto.Items.Any(x => x.Quantity > 0)) {
            return false;
        }

        // If the total order value exceeds €5,000, the `RequiresApproval` flag must be automatically set to `true`
        // TODO => Auslagern in OrderCalculationDomain bzw. separate Methode
        if (orderDto.Items.Count(x => x.UnitPrice * x.Quantity)) {
            orderDto.RequiresApproval = true;

            // TODO Log Approval CHange
        }

        // Validate OrderItems
        foreach (var item in orderDto.Items) {
            if (!_orderItemDomain.IsValid(item)) {
                return false;
            }
        }

        return true;
    }
}


