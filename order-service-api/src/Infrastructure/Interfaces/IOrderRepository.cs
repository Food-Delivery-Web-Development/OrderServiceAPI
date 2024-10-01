using OrderServiceAPI.src.Domain;

namespace OrderServiceAPI.src.Infrastructure.Interfaces;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task<IEnumerable<Order>> GetUserOrders(Guid id);
    Task<IEnumerable<Order>> GetUserDayOrders(Guid id);
    Task AddItemToOrder(Guid orderId, OrderItem item);
    Task SetOrderStatus(Guid orderId, OrderStatus orderStatus);
}
