using OrderServiceAPI.src.Domain;

namespace OrderServiceAPI.src.Infrastructure.Interfaces;

public interface IOrderItemRepository : IBaseRepository<OrderItem>
{
    Task<IEnumerable<OrderItem>> GetUserOrderItems(Guid orderId);
}
