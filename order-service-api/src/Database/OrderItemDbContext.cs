using Microsoft.EntityFrameworkCore;
using OrderServiceAPI.src.Domain;

namespace OrderServiceAPI.src.Database;

public class OrderItemDbContext : DbContext
{
    public DbSet<OrderItem> OrderItems{ get; set; }

    public OrderItemDbContext(DbContextOptions<OrderItemDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.Property(u => u.OrderId).IsRequired();
            entity.Property(u => u.ProductId).IsRequired();
            entity.Property(u => u.Quantity).IsRequired();
            entity.Property(u => u.UnitPrice).IsRequired();
        });
    }
}