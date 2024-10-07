using OrderServiceAPI.src.Domain;

namespace OrderServiceAPI.src.Infrastructure.Interfaces;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task<IEnumerable<Order>> GetUserOrdersAsync(Guid id);
    Task<IEnumerable<Order>> GetUserDayOrdersAsync(Guid id);
    Task AddItemToOrderAsync(Guid orderId, OrderItem item);
    Task SetOrderStatusAsync(Guid orderId, OrderStatus orderStatus);
}
