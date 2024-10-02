namespace OrderServiceAPI.src.Domain;

public class OrderItem
{
    public Guid Id { get; init; }  = Guid.NewGuid();
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public required Order Order { get; set; }
}
