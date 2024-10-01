using OrderServiceAPI.src.Domain;

namespace OrderServiceAPI.src.Infrastructure.Interfaces;

public interface IOrderItemRepository : IRepository<OrderItem>
{
    Task<IEnumerable<OrderItem>> GetUserOrderItmes(Guid id);
}
