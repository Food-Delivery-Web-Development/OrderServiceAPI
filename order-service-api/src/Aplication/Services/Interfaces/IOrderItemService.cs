using OrderServiceAPI.src.Domain;

namespace OrderServiceAPI.src.Aplication.Services.Interfaces;

public interface IOrderItemService : IBaseService<OrderItem>
{
    Task<IEnumerable<OrderItem>> GetUserOrderItems(Guid orderId);
}