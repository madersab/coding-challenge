namespace Shared.Models.DTos {
    public class CreateOrderDto {
        int CustomerId {get; set;}
        IEnumerable<OrderItemDto> Items {get; set;}
        bool RequiresApproval {get; set;}
    }
}

