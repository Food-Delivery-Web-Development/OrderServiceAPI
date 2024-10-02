using OrderServiceAPI.src.Aplication.Services.Interfaces;
using OrderServiceAPI.src.Domain;
using OrderServiceAPI.src.Infrastructure.Interfaces;

namespace OrderServiceAPI.src.Aplication.Services.Concretes;

public class OrderItemService : IOrderItemService
{
    private readonly IOrderItemRepository _orderItemRepository;

    public OrderItemService(IOrderItemRepository orderItemRepository)
    {
        _orderItemRepository = orderItemRepository;
    }

    public async Task AddAsync(OrderItem entity)
    {
        await _orderItemRepository.AddAsync(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _orderItemRepository.DeleteAsync(id);
    }

    public async Task<OrderItem?> GetByIdAsync(Guid id)
    {
        return await _orderItemRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<OrderItem>> GetUserOrderItems(Guid orderId)
    {
        return await _orderItemRepository.GetUserOrderItems(orderId);
    }

    public async Task UpdateAsync(OrderItem entity)
    {
        await _orderItemRepository.UpdateAsync(entity);
    }
}