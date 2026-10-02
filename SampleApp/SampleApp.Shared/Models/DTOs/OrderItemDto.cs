namespace Shared.Models.DTos;

public class OrderItemDto {
    // Article Identifier
    int ArticleId {get; set;}
    
    // Producer Number
    string? SKU {get; set;}

    // Article Quantity
    int Quantity {get; set;}

    // Article Position
    int OrderItemPosition {get; set;}

    // Unit Price
    decimal UnitPrice {get; set;}
}


