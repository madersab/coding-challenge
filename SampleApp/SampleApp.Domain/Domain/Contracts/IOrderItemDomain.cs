namespace Domain.Domain.Contracts;

public interface IOrderItemDomain {
    // <summary>
    // Validate OrderItem
    // </summary>
    bool IsValid(OrderItemDto orderItem)
}