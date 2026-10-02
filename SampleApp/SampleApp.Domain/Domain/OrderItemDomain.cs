namespace Domain.Domain;

public class OrderItemDomain {
    // </inheritdoc>
    internal bool IsValid(OrderItemDto orderItem) {
        if (orderItem.Quantity <= 0) {
            return false;
        }

        if (orderItem.UnitPrice <= 0) {
            return false;
        }

        return true;
    }
}