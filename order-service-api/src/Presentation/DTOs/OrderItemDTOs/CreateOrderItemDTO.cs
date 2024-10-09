using OrderServiceAPI.src.Domain;

namespace src.Presentation.DTOs.OrderItemDTOs;

public class CreateOrderItemDTO 
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}