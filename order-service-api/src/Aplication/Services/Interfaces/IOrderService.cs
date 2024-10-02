using OrderServiceAPI.src.Domain;

namespace OrderServiceAPI.src.Aplication.Services.Interfaces;

public interface IOrderService : IBaseService<Order>
{
    Task<IEnumerable<Order>> GetUserOrdersAsync(Guid id);
    Task<IEnumerable<Order>> GetUserDayOrdersAsync(Guid id);
    Task AddItemToOrderAsync(Guid orderId, OrderItem item);
    Task SetOrderStatusAsync(Guid orderId, OrderStatus orderStatus);
}