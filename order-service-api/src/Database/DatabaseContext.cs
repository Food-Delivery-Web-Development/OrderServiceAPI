using Microsoft.EntityFrameworkCore;
using OrderServiceAPI.src.Domain;

namespace OrderServiceAPI.src.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.CustomerId).IsRequired();
                entity.Property(u => u.Status).IsRequired();
                entity.Property(u => u.OrderDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(u => u.TotalAmount).IsRequired();
            });

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
}
