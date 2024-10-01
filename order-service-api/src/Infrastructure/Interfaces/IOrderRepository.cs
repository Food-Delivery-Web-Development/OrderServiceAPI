using OrderServiceAPI.src.Domain;

namespace OrderServiceAPI.src.Infrastructure.Interfaces;

public interface IOrderRepository : IRepository<Order>
{
    Task<IEnumerable<Order>> GetUserOrders(Guid id);
    Task<IEnumerable<Order>> GetUserDayOrders(Guid id);
}
