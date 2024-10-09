namespace src.Presentation.DTOs.OrderDTOs;

public class CreateOrderDTO
{
    public Guid CustomerId { get; set; }
    public OrderStatus Status { get; set; }
    public decimal TotalAmount { get; set; }
}