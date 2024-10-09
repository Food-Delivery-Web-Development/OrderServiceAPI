using OrderServiceAPI.src.Domain;

namespace src.Presentation.DTOs.OrderItemDTOs;

public class UpdateOrderItemDTO 
{
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}