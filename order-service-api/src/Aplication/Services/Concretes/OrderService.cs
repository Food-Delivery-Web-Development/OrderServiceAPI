using OrderServiceAPI.src.Aplication.Services.Interfaces;
using OrderServiceAPI.src.Domain;
using OrderServiceAPI.src.Infrastructure.Interfaces;

namespace OrderServiceAPI.src.Aplication.Services.Concretes;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task AddAsync(Order entity)
    {
        await _orderRepository.AddAsync(entity);
    }


    public async Task DeleteAsync(Guid id)
    {
        await _orderRepository.DeleteAsync(id);
    }

    public async Task<Order?> GetByIdAsync(Guid id)
    {
        return await _orderRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Order>> GetUserDayOrdersAsync(Guid id)
    {
        return await _orderRepository.GetUserDayOrdersAsync(id);
    }

    public async Task<IEnumerable<Order>> GetUserOrdersAsync(Guid id)
    {
        return await _orderRepository.GetUserOrdersAsync(id);
    }

    public async Task UpdateAsync(Order entity)
    {
        await _orderRepository.UpdateAsync(entity);
    }
}