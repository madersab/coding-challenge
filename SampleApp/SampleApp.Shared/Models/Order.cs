namespace Shared.Models;

public class Order {
    int CustomerId {get; set;}

    IEnumerable<OrderItemDto> Items {get; set;}
    
    bool RequiresApproval {get; set;}
}


