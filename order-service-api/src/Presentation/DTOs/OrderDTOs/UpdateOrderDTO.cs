using OrderServiceAPI.src.Domain;

namespace src.Presentation.DTOs.OrderDTOs;

public class UpdateOrderDTO
{
    public OrderStatus Status { get; set; }
    public decimal TotalAmount { get; set; }
}