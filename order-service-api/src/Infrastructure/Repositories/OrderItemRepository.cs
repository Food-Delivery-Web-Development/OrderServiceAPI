using OrderServiceAPI.src.Domain;
using OrderServiceAPI.src.Infrastructure.Interfaces;

namespace OrderServiceAPI.src.Infrastructure.Repositories;

public class OrderItemRepositpry : IOrderItemRepository
{
    public Task AddAsync(OrderItem entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<OrderItem?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<OrderItem>> GetUserOrderItmes(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(OrderItem entity)
    {
        throw new NotImplementedException();
    }
}