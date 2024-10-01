using Microsoft.EntityFrameworkCore;
using OrderServiceAPI.src.Database;
using OrderServiceAPI.src.Domain;
using OrderServiceAPI.src.Infrastructure.Interfaces;

namespace OrderServiceAPI.src.Infrastructure.Repositories;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly OrderItemDbContext _context;

    public OrderItemRepository(OrderItemDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(OrderItem orderItem)
    {
        await _context.OrderItems.AddAsync(orderItem);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var order = await _context.OrderItems.FindAsync(id);
        if (order != null)
        {
            _context.OrderItems.Remove(order);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<OrderItem?> GetByIdAsync(Guid id)
    {
        return await _context.OrderItems.FindAsync(id);
    }

    public async Task<IEnumerable<OrderItem>> GetUserOrderItems(Guid orderId)
    {
        return await _context.OrderItems
            .Where(o => o.OrderId == orderId)
            .ToListAsync();
    }

    public async Task UpdateAsync(OrderItem entity)
    {
        _context.OrderItems.Update(entity);
        await _context.SaveChangesAsync();
    }
}