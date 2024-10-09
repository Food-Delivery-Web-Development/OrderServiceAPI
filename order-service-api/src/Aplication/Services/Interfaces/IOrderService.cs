using OrderServiceAPI.src.Domain;

namespace OrderServiceAPI.src.Aplication.Services.Interfaces;

public interface IOrderService : IBaseService<Order>
{
    Task<IEnumerable<Order>> GetUserOrdersAsync(Guid id);
    Task<IEnumerable<Order>> GetUserDayOrdersAsync(Guid id);
}