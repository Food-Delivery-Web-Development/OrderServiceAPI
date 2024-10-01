using Microsoft.EntityFrameworkCore;
using OrderServiceAPI.src.Domain;

namespace OrderServiceAPI.src.Database;

public class OrderDbContext : DbContext
{
    public DbSet<Order> Orders{ get; set; }

    public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(u => u.Id);
            entity.Property(u => u.CustomerId).IsRequired();
            entity.Property(u => u.Items).IsRequired();
            entity.Property(u => u.Status).IsRequired();
            entity.Property(u => u.OrderDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
            entity.Property(u => u.TotalAmount).IsRequired();
        });
    }
}