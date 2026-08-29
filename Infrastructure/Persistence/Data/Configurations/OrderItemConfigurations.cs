using Domain.Models.OrderModule;

namespace Persistence.Data.Configurations;

public class OrderItemConfigurations : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("orderItems");
        builder.Property(oi => oi.Price).HasColumnType("decimal(8,2)");
        builder.OwnsOne(o => o.Product);
    }
}
