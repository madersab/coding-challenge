namespace Domain.Domain;
public interface IOrderDomain {    
    /// <summary>
    /// Creates a new Order
    /// </summary>
    public Task<Result<CreateOrderDto>> CreateOrderAsync(CreateOrderDto orderDto);
}

