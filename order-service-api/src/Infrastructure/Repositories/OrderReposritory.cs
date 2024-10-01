using OrderServiceAPI.src.Domain;
using OrderServiceAPI.src.Infrastructure.Interfaces;

namespace OrderServiceAPI.src.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    public Task AddAsync(Order entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Order?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Order>> GetUserOrders(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Order>> GetUserDayOrders(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Order entity)
    {
        throw new NotImplementedException();
    }
}
