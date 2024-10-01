using Microsoft.EntityFrameworkCore;
using OrderServiceAPI.src.Domain;
using OrderServiceAPI.src.Infrastructure.Interfaces;
using OrderServiceAPI.src.Database;

namespace OrderServiceAPI.src.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly OrderDbContext _context;

    public OrderRepository(OrderDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order != null)
        {
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<Order?> GetByIdAsync(Guid id)
    {
        return await _context.Orders.FindAsync(id);
    }

    public async Task<IEnumerable<Order>> GetUserOrders(Guid customerId)
    {
        return await _context.Orders
            .Where(o => o.CustomerId == customerId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Order>> GetUserDayOrders(Guid customerId)
    {
        var today = DateTime.UtcNow.Date;
        return await _context.Orders
            .Where(o => o.CustomerId == customerId && o.OrderDate.Date == today)
            .ToListAsync();
    }

    public async Task UpdateAsync(Order entity)
    {
        _context.Orders.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task AddItemToOrder(Guid orderId, OrderItem item)
    {
        var order = await _context.Orders.FindAsync(orderId);
        if (order != null)
        {
            order.Items.Add(item);
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
    }


    public async Task SetOrderStatus(Guid orderId, OrderStatus orderStatus)
    {
        var order = await _context.Orders.FindAsync(orderId);
        if (order != null)
        {
            order.Status = orderStatus;
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }
    }
}
